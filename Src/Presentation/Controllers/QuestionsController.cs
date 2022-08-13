using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Questions.Commands.DeleteQuestion;
using Application.Questions.Commands.UpsertQuestion;
using Application.Questions.Queries.GetQuestions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.Base;

namespace Presentation.Controllers
{
    public class QuestionsController : BaseController
    {
        /// <summary>
        /// Get All Questions List
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<QuestionListDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<QuestionListDto>>> GetAll() => Ok(await Mediator.Send(new GetQuestionsQuery()));

        /// <summary>
        /// Add / Update a Question
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> Upsert([FromBody] UpsertQuestionCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }
        
        /// <summary>
        /// Delete a question
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Delete([FromBody] DeleteQuestionCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }
    }
}