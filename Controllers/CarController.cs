using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ObliOPG4OPG.Repos;
using _3SemObliOPG;


namespace ObliOPG4OPG.Controllers
{
    [Route("api/biler")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private CarRepo _repo;

        public CarController(CarRepo repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Car>> GetAll()
        {
            return _repo.GetAll();
        }
        #region
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public ActionResult<Car> Get(int id)
        {
            try
            {
                Car FoundCarId = _repo.GetById(id);
                return Ok(FoundCarId);
            }
            catch (ArgumentNullException ex)
            {

                return BadRequest(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {

                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {

                return BadRequest(ex.Message);
            }
        }
        #endregion
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<Car> Post([FromBody] Car newcar)
        {
            try
            {
                Car createdCar = _repo.Add(newcar);
                return Created($"api/cars/{createdCar.Id}", createdCar);
            }
            catch (ArgumentNullException ex)
            {

                return BadRequest(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {

                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public ActionResult<Car> Put(int id, [FromBody] Car _UpdateCar)
        {
            try
            {
                Car UpdatedCar = _repo.Update(id, _UpdateCar);
                if (UpdatedCar == null)
                {
                    return NotFound();
                }
                return Ok(UpdatedCar);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public void Delete(int id, Car car)
        {
            _repo.Delete(id, car);
        }
    }
}
