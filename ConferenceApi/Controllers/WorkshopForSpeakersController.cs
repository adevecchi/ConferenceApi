using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using AutoMapper;

using Conference.Data;
using Conference.Service;
using ConferenceApi.Models;

namespace ConferenceApi.Controllers;

[ApiController]
[Route("api/speakers/{speakerId}/workshops")]
public class WorkshopsForSpeakersController : ControllerBase
{
    private readonly IWorkshopsRepository workshopsRepository;
    private readonly ISpeakersService speakersService;
    private readonly IMapper mapper;

    public WorkshopsForSpeakersController(IWorkshopsRepository workshopsRepository, ISpeakersService speakersService, IMapper mapper)
    {
        this.workshopsRepository = workshopsRepository;
        this.speakersService = speakersService;
        this.mapper = mapper;
    }

    [HttpGet(Name = "GetWorkshopsForSpeaker")]
    public ActionResult<IEnumerable<WorkshopModel>> GetWorkshopsForSpeaker(int speakerId)
    {
        if (!speakersService.CheckIfExists(speakerId))
        {
            return NotFound();
        }
        var workshopsForSpeaker = workshopsRepository.GetWorkshopsForSpeaker(speakerId);
        var workshopModels = mapper.Map<IEnumerable<WorkshopModel>>(workshopsForSpeaker).ToList();
        return Ok(workshopModels);
    }

    [HttpGet("{workshopId}", Name = "GetWorkshopForSpeaker")]
    public ActionResult<WorkshopModel> GetWorkshopsForSpeaker(int speakerId, int workshopId)
    {
        if (!speakersService.CheckIfExists(speakerId))
        {
            return NotFound();
        }

        var workshopForSpeaker = workshopsRepository.GetWorkshop(speakerId, workshopId);

        if (workshopForSpeaker == null)
        {
            return NotFound();
        }
        
        var workshopModel = mapper.Map<WorkshopModel>(workshopForSpeaker);
        return Ok(workshopModel);
    }
}
