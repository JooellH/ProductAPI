using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Data;
using ProductAPI.Models;
using AutoMapper;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

[ApiController]
[Route("api/categorias")]
public class CategoriasController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public CategoriasController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoriaDto>>> GetAll()
    {
        var categorias = await _context.Categorias.ToListAsync();
        return Ok(_mapper.Map<IEnumerable<CategoriaDto>>(categorias));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CategoriaDto>> GetById(int id)
    {
        var categoria = await _context.Categorias.FindAsync(id);
        if (categoria == null) return NotFound();
        return Ok(_mapper.Map<CategoriaDto>(categoria));
    }

    [HttpPost]
    public async Task<ActionResult> Create(CategoriaDto dto)
    {
        var categoria = _mapper.Map<Categoria>(dto);
        _context.Categorias.Add(categoria);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = categoria.Id }, dto);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var categoria = await _context.Categorias.Include(c => c.Productos).FirstOrDefaultAsync(c => c.Id == id);
        if (categoria == null) return NotFound();
        if (categoria.Productos.Any()) return BadRequest("No se puede eliminar una categoría con productos.");
        _context.Categorias.Remove(categoria);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}