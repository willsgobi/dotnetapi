using ApiCatalogo.DTOs;
using ApiCatalogo.Models;
using ApiCatalogo.Pagination;
using ApiCatalogo.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiCatalogo.Controllers {
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    //[Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase {
        private readonly IUnityOfWork _uof;
        private readonly IMapper _mapper;

        public CategoriasController(IUnityOfWork context, IMapper mapper) {
            _uof = context;
            _mapper = mapper;
        }

        [HttpGet("produtos")]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> GetCategoriasProdutos() {
            var categorias = await _uof.CategoriaRepository.GetCategoriasProdutos();
            var categoriasDto = _mapper.Map<List<CategoriaDTO>>(categorias);
            return categoriasDto;
        }

        //[HttpGet]
        //public ActionResult<IEnumerable<CategoriaDTO>> Get([FromQuery] CategoriaParameters categoriasParameters) {
        //    var categorias = _uof.CategoriaRepository.GetCategorias(categoriasParameters);

        //    var metadata = new {
        //        categorias.TotalCount,
        //        categorias.PageSize,
        //        categorias.CurrentPage,
        //        categorias.TotalPages,
        //        categorias.HasNext,
        //        categorias.HasPrevious
        //    };

        //    Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

        //    var categoriasDTO = _mapper.Map<List<CategoriaDTO>>(categorias);
        //    return categoriasDTO;
        //}

        [HttpGet]
        public ActionResult<IEnumerable<CategoriaDTO>> Get() {
            try {
                var categorias = _uof.CategoriaRepository.Get();

                //var metadata = new {
                //    categorias.TotalCount,
                //    categorias.PageSize,
                //    categorias.CurrentPage,
                //    categorias.TotalPages,
                //    categorias.HasNext,
                //    categorias.HasPrevious
                //};

                //Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

                var categoriasDTO = _mapper.Map<List<CategoriaDTO>>(categorias);
                //throw new Exception();
                return categoriasDTO;
            } catch (Exception) {
                return BadRequest();
            }
        }

        /// <summary>
        /// Obtem uma categoria por ID
        /// </summary>
        /// <param name="id">código da categoria</param>
        /// <returns>objetos categoria</returns>
        [HttpGet("{id}", Name = "ObterCategoria")]
        public async Task<ActionResult<CategoriaDTO>> Get(int id) {
            var categoria = await _uof.CategoriaRepository.GetById(c => c.CategoriaId == id);

            if (categoria == null) {
                return NotFound();
            } else {
                var categoriaDTO = _mapper.Map<CategoriaDTO>(categoria);
                return categoriaDTO;
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoriaDTO categoriaDto) {
            var categoria = _mapper.Map<Categoria>(categoriaDto);
            _uof.CategoriaRepository.Add(categoria);
            await _uof.Commit();

            var categoriaDTO = _mapper.Map<CategoriaDTO>(categoria);
            return new CreatedAtRouteResult("ObterCategoria", new { id = categoria.CategoriaId }, categoriaDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] CategoriaDTO categoriaDto) {
            if (id != categoriaDto.CategoriaId) {
                return NotFound();
            }

            var categoria = _mapper.Map<Categoria>(categoriaDto);
            _uof.CategoriaRepository.Update(categoria);
            await _uof.Commit();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoriaDTO>> Delete(int id) {
            var categoria = await _uof.CategoriaRepository.GetById(c => c.CategoriaId == id);

            if (categoria == null) {
                return NotFound();
            }

            _uof.CategoriaRepository.Delete(categoria);
            await _uof.Commit();

            var categoriaDto = _mapper.Map<CategoriaDTO>(categoria);

            return categoriaDto;
        }
    }
}