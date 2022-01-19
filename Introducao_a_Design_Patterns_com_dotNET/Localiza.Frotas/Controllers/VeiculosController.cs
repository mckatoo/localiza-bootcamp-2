using System;
using Localiza.Frotas.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Localiza.Frotas.Controllers
{
  [Route("api/v1/[controller]")]
  public class VeiculosController : Controller
  {
    private readonly IVeiculoRepository _veiculoRepository;

    public VeiculosController(IVeiculoRepository veiculoRepository)
    {
      _veiculoRepository = veiculoRepository;
    }

    [HttpGet]
    public IActionResult ListaTodos() => Ok(_veiculoRepository.ListaTodos());

    [HttpGet("{id}")]
    public IActionResult PorID(Guid id) 
    {
      var veiculo = _veiculoRepository.PorID(id);
      if (veiculo == null)
        return NotFound($"Veiculo com o ID {id} não encontrado");

      return Ok(veiculo);
    }

    [HttpGet("placa/{placa}")]
    public IActionResult PorPlaca(string placa) 
    {
      var veiculo = _veiculoRepository.PorPlaca(placa);
      if (veiculo == null)
        return NotFound($"Veiculo com a placa {placa} não encontrado");

      return Ok(veiculo);
    }

    [HttpGet("marca/{marca}")]
    public IActionResult PorMarca(string marca) 
    {
      IEnumerable<Veiculo> veiculos = _veiculoRepository.ListaPorMarca(marca);
      if (veiculos.Count() == 0)
        return NotFound($"Veiculos com a marca {marca} não encontrados");

      return Ok(veiculos);
    }

    [HttpGet("ano_fabricacao/{ano_fabricacao}")]
    public IActionResult PorAnoFabricacao(string ano_fabricacao) 
    {
      IEnumerable<Veiculo> veiculos = _veiculoRepository.ListaPorAnoFabricacao(ano_fabricacao);
      if (veiculos.Count() == 0)
        return NotFound($"Veiculos de {ano_fabricacao} não encontrados");

      return Ok(veiculos);
    }

    [HttpPost]
    public IActionResult Salvar([FromBody] Veiculo veiculo)
    {
      if (veiculo == null)
      {
        return BadRequest();
      }
      _veiculoRepository.Salvar(veiculo);
      return CreatedAtAction(nameof(PorID), new { id = veiculo.Id }, veiculo);
    }

    [HttpPut("{id}")]
    public IActionResult Atualizar(Guid id, [FromBody] Veiculo veiculo)
    {
      if (veiculo == null)
      {
        return BadRequest();
      }
      var veiculoAtual = _veiculoRepository.PorID(id);
      if (veiculoAtual == null)
      {
        return NotFound();
      }
      _veiculoRepository.Atualizar(veiculoAtual);
      return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Excluir(Guid id)
    {
      var veiculoAtual = _veiculoRepository.PorID(id);
      if (veiculoAtual == null)
      {
        return NotFound();
      }
      _veiculoRepository.Excluir(veiculoAtual);
      return NoContent();
    }
  }
}