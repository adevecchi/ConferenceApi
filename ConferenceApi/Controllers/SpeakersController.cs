using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Conference.Domain.Entities;
using Conference.Service;
using ConferenceApi.Models;

namespace ConferenceApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SpeakersController : ControllerBase
{
    private readonly ISpeakersService speakersService;
    private readonly IMapper mapper;

    public SpeakersController(ISpeakersService speakersService, IMapper mapper)
    {
        this.speakersService = speakersService;
        this.mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<SpeakerModel>> GetAll()
    {
        var speakers = speakersService.GetAll();
        var speakerModels = mapper.Map<IEnumerable<SpeakerModel>>(speakers);
        return Ok(speakerModels);
    }

    [HttpGet("{id}")]
    public IActionResult GetbyId(int id)
    {
        var speakerToReturn = speakersService.Get(id);
        if (speakerToReturn == null)
        {
            return NotFound();
        }
        return Ok(speakerToReturn);
    }

    [HttpHead("{id}")]
    public IActionResult CheckIfExists(int id)
    {
        var speakerToReturn = speakersService.CheckIfExists(id);
        if (speakerToReturn == false)
        {
            return NotFound();
        }
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, SpeakerModel model)
    {
        var speakerFromDb = speakersService.Get(id);
        if (speakerFromDb == null)
        {
            return NotFound();
        }
        TryUpdateModelAsync(speakerFromDb);
        speakersService.Update(speakerFromDb);
        return Ok(speakerFromDb);
    }

    [HttpPost]
    public IActionResult Post(SpeakerModel model)
    {
        var speakerToAdd = mapper.Map<Speaker>(model);
        speakersService.Add(speakerToAdd);
        return CreatedAtAction(nameof(GetbyId), new { id = speakerToAdd.Id }, speakerToAdd);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var speakerFromDb = speakersService.Get(id);
        if (speakerFromDb == null)
        {
            return NotFound();
        }
        speakersService.Delete(speakerFromDb);
        return NoContent();
    }
}
