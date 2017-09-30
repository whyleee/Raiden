using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GameStore.Business;
using GameStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class GamesController : Controller
    {
        private readonly GameStorage _gameStorage;

        public GamesController(GameStorage gameStorage)
        {
            _gameStorage = gameStorage;
        }

        [HttpGet]
        public Task<IList<Game>> Get(CancellationToken ct)
        {
            return _gameStorage.GetAllAsync(ct);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id, CancellationToken ct)
        {
            var value = await _gameStorage.GetByIdAsync(id, ct);

            if (value == null)
            {
                return NotFound();
            }

            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody][Required]Game game, CancellationToken ct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _gameStorage.InsertAsync(game, ct);

            return Ok(game);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody][Required]Game game, CancellationToken ct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            game.Id = id;
            var result = await _gameStorage.ReplaceAsync(game, ct);

            if (result.MatchedCount == 0)
            {
                return NotFound();
            }

            return Ok(game);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id, CancellationToken ct)
        {
            var result = await _gameStorage.DeleteAsync(id, ct);

            if (result.DeletedCount == 0)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
