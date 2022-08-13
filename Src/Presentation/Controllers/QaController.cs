using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Qa.Commands.Create;
using Application.Questions.Queries.GetQuestionsWithAnswers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.Base;

namespace Presentation.Controllers
{
    public class QaController : BaseController
    {
        /// <summary>
        /// Get All Questions With Answers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<QuestionWithAnswerListDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<QuestionWithAnswerListDto>>> List() =>
            Ok(await Mediator.Send(new GetQuestionsWithAnswersQuery()));
        
        /// <summary>
        /// Answer The Questions
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<List<QuestionWithAnswerListDto>>> Create([FromBody] QaCreateCommand command) 
        {
            await Mediator.Send(command);
            return NoContent();
        }
    }
}