using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Formats.Jpeg;

namespace WebApiWithCompressionResponse.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompressaoController : ControllerBase
    {
        private readonly string _imageFolder = "wwwroot/imagens_comprimidas";

        public CompressaoController()
        {
            if (!Directory.Exists(_imageFolder))
                Directory.CreateDirectory(_imageFolder);
        }

        [HttpPost("compress")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> CompressImage([FromForm] IFormFile file, [FromQuery] int quality = 75)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Nenhuma imagem enviada.");

            using var image = await Image.LoadAsync(file.OpenReadStream());

            image.Mutate(x => x.Resize(new ResizeOptions
            {
                Mode = ResizeMode.Max,
                Size = new Size(1024, 0)
            }));

            var fileName = $"{Guid.NewGuid()}.jpg";
            var filePath = Path.Combine(_imageFolder, fileName);

            await image.SaveAsync(filePath, new JpegEncoder { Quality = quality });

            var imageUrl = $"{Request.Scheme}://{Request.Host}/api/imagem/resgatar/{fileName}";
            return Ok(new { message = "Imagem comprimida com sucesso", url = imageUrl });
        }

        [HttpGet("resgatar/{nomeArquivo}")]
        public IActionResult ResgatarImagem(string nomeArquivo)
        {
            var caminhoImagem = Path.Combine(_imageFolder, nomeArquivo);

            if (!System.IO.File.Exists(caminhoImagem))
                return NotFound("Imagem não encontrada.");

            var imagemBytes = System.IO.File.ReadAllBytes(caminhoImagem);
            var contentType = "image/jpeg";

            return File(imagemBytes, contentType);
        }
    }
}
