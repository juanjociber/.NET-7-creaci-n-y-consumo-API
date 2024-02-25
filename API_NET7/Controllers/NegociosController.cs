using API_NET7.Datos;
using API_NET7.Modelos;
using API_NET7.Modelos.DTO;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_NET7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NegociosController : ControllerBase
    {
        //Inyección de dependencia: ILogger
        private readonly ILogger<NegociosController> _logger;

        //Inyeccion de dependencia: DbContext
        private readonly ApplicationDbContext _db;

        //Inyeccion de dependencia:IMapper 
        private readonly IMapper _mapper;

        //Constructor que permite la inyección de dependencias
        public NegociosController(ILogger<NegociosController> logger, ApplicationDbContext db, IMapper mapper) {
            _logger = logger;
            _db = db;
            _mapper = mapper;
        }


        //LISTAR
        [HttpGet]
        //Documentando API
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult <IEnumerable<VillaDTO>>> GetVillas()
        {
            _logger.LogInformation("Obtener las Villas");

            IEnumerable<Villa> villaList = await _db.Villas.ToListAsync();

            return Ok(_mapper.Map<IEnumerable<VillaDTO>>(villaList));
        }

        //lISTAR POR ID
        [HttpGet("id:int", Name ="GetVilla")]
        //Documentando API
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VillaDTO>> GetVilla(int id)
        {

            if(id == 0)
            {
                _logger.LogError("Error al traer con la Villa de id: " + id);
                return BadRequest();
            }
            var villa = await _db.Villas.FirstOrDefaultAsync(v => v.Id == id);

            if (villa == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<VillaDTO>(villa));
        }

        //CREAR
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<VillaDTO>> CrearVilla([FromBody] VillaCreateDTO createDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _db.Villas.FirstOrDefaultAsync(v => v.Nombre.ToLower() == createDTO.Nombre.ToLower()) != null)
            {
                ModelState.AddModelError("NombreExiste", "La Villa con ese nombre ya existe");
                return BadRequest(ModelState);
            }

            if (createDTO == null)
            {
                return BadRequest(createDTO);
            }

            Villa modelo = _mapper.Map<Villa>(createDTO);

            await _db.Villas.AddAsync(modelo);
            await _db.SaveChangesAsync();
            return CreatedAtRoute("GetVilla", new {id = modelo.Id, modelo});
        }

        //ELIMINAR
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteVilla(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            var villa = await _db.Villas.FirstOrDefaultAsync(v => v.Id == id);

            if(villa == null)
            {
                return NotFound();
            }
            _db.Villas.Remove(villa);
            await _db.SaveChangesAsync();

            return NoContent();
        }

        //ACTUALIZAR
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateVilla(int id, [FromBody] VillaUpdateDTO updateDTO)
        {
            if(updateDTO == null || id != updateDTO.Id)
            {
                return BadRequest();
            }

            Villa model = _mapper.Map<Villa>(updateDTO);

            _db.Villas.Update(model);
            await _db.SaveChangesAsync();
            return NoContent();
        }

        //Actuliza por propiedad
        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateVilla(int id, JsonPatchDocument<VillaUpdateDTO> patchDTO)
        {
            if (patchDTO == null || id == 0)
            {
                return BadRequest();
            }
            var villa = await _db.Villas.AsNoTracking().FirstOrDefaultAsync(v => v.Id == id);

            VillaUpdateDTO villaDTO = _mapper.Map<VillaUpdateDTO>(villa);

            if(villa == null)
            {
                return BadRequest();
            }
            
            patchDTO.ApplyTo(villaDTO, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Villa modelo = _mapper.Map<Villa>(villaDTO);

            _db.Villas.Update(modelo);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
