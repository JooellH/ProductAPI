using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Data;
using ProductAPI.Models;
using AutoMapper;
using System.Threading.Tasks;
using System.Collections.Generic;

[ApiController]
[Route("api/productos")]
public class ProductosController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public ProductosController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductoDto>>> GetAll()
    {
        var productos = await _context.Productos.Include(p => p.Categoria).ToListAsync();
        return Ok(_mapper.Map<IEnumerable<ProductoDto>>(productos));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductoDto>> GetById(int id)
    {
        var producto = await _context.Productos.Include(p => p.Categoria).FirstOrDefaultAsync(p => p.Id == id);
        if (producto == null) return NotFound();
        return Ok(_mapper.Map<ProductoDto>(producto));
    }

    [HttpPost]
    public async Task<ActionResult> Create(ProductoCreateDto dto)
    {
        if (!await _context.Categorias.AnyAsync(c => c.Id == dto.CategoriaId))
            return BadRequest("La categoría especificada no existe.");

        var producto = _mapper.Map<Producto>(dto);
        _context.Productos.Add(producto);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = producto.Id }, producto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, ProductoCreateDto dto)
    {
        var producto = await _context.Productos.FindAsync(id);
        if (producto == null) return NotFound();

        if (!await _context.Categorias.AnyAsync(c => c.Id == dto.CategoriaId))
            return BadRequest("La categoría especificada no existe.");

        _mapper.Map(dto, producto);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var producto = await _context.Productos.FindAsync(id);
        if (producto == null) return NotFound();

        _context.Productos.Remove(producto);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}