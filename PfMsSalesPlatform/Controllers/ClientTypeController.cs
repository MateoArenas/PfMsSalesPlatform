using MediatR;
using Microsoft.AspNetCore.Mvc;
using PfMsSalesPlatform.Application.Commands.Clients;
using PfMsSalesPlatform.Application.DTOs;
using PfMsSalesPlatform.Application.Querys.Clients;

namespace PfMsSalesPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientTypeController : Controller
    {
        private readonly IMediator _mediatoR;

        public ClientTypeController(IMediator mediatoR)
        {
            _mediatoR = mediatoR;
        }

        [HttpGet]
        public async Task<ActionResult<List<ClientTypeDto>>> GetAll() 
        {
            List<ClientTypeDto> clientTypeDtoList = await _mediatoR.Send(new GetAllClientTypeQuery());

            return Ok(clientTypeDtoList);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<List<ClientTypeDto>>> GetOne(int Id)
        {
            ClientTypeDto? clientTypeDto = await _mediatoR.Send(new GetOneClientTypeQuery(Id));
            if (clientTypeDto == null)
                return NotFound();

            return Ok(clientTypeDto);
        }

        [HttpPost]
        public async Task<ActionResult<ClientTypeDto>> Create(CreateClientTypeCommand createClientTypeCommand) 
        { 
            ClientTypeDto? clientTypeDto = await _mediatoR.Send(createClientTypeCommand);
            if (clientTypeDto == null)
                return NotFound();

            return Ok(clientTypeDto);
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<ClientTypeDto>> Update(int Id, UpdateClientTypeCommand updateClientTypeCommand)
        {
            if(Id != updateClientTypeCommand.ClientTypeDto.Id)
                return NotFound();

            ClientTypeDto? clientTypeDto = await _mediatoR.Send(updateClientTypeCommand);
            if (clientTypeDto == null)
                return NotFound();

            return Ok(clientTypeDto);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<ClientTypeDto>> Delete(int Id)
        {
            bool result = await _mediatoR.Send(new DeleteClientTypeCommand(Id));

            if (!result)
                return NotFound();

            return Ok(result);
        }
    }
}
