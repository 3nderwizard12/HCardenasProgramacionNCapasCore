using Microsoft.AspNetCore.Mvc;

namespace SL.Controllers
{
    public class AseguradoraController : Controller
    {
        [Route("api/Aseguradora/GetAll")]
        [HttpGet]
        public IActionResult GetAll()
        {
            ML.Result result = BL.Aseguradora.GetAll();
            
            if (result.Correct)
            {
                return Ok(result.Objects);
            }
            else { return NotFound(result); }
        }

        [Route("api/Aseguradora/Add")]
        [HttpPost]
        public IActionResult Add([FromBody] ML.Aseguradora aseguradora)
        {
            ML.Result result = BL.Aseguradora.Add(aseguradora);
            if (result.Correct)
            {
                return Ok(result.Objects);
            }
            else { return NotFound(result); }
        }

        [Route("api/Aseguradora/Delete/{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            ML.Aseguradora aseguradora = new ML.Aseguradora();
            aseguradora.IdAseguradora = id;
            ML.Result result = BL.Aseguradora.Delete(aseguradora);
            if (result.Correct)
            {
                return Ok(result.Object);
            }
            else { return NotFound(result); }
        }

        [Route("api/Aseguradora/Update/{id}")]
        [HttpPut]
        public IActionResult Update(int id, [FromBody] ML.Aseguradora aseguradora)
        {
            aseguradora.IdAseguradora = id;
            ML.Result result = BL.Aseguradora.Update(aseguradora);

            if (result.Correct)
            {
                return Ok(result.Object);
            }
            else { return NotFound(result); }
        }

        [Route("api/Aseguradora/GetById/{id}")]
        [HttpGet]
        public IActionResult GetById(int id)
        {
            ML.Result result = BL.Aseguradora.GetById(id);

            if (result.Correct)
            {
                return Ok(result.Object);
            }
            else { return NotFound(result); }
        }
    }
}