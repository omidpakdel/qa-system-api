using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Answers.Commands.DeleteAnswer;
using Application.Answers.Commands.UpsertAnswer;
using Application.Answers.Queries.GetQuestionAnswers;
using Application.Questions.Commands.DeleteQuestion;
using Application.Questions.Commands.UpsertQuestion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.Base;

namespace Presentation.Controllers
{
    public class AnswersController : BaseController
    {
        /// <summary>
        /// Get Answers of a Question
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<QuestionAnswersDto>>> GetQuestionAnswers(
            [FromQuery] GetQuestionAnswersQuery query) => Ok(await Mediator.Send(query));
        
        /// <summary>
        /// Add / Update an Answer
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> Upsert([FromBody] UpsertAnswerCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }
        
        /// <summary>
        /// Delete an answer
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Delete([FromBody] DeleteAnswerCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }
    }
}