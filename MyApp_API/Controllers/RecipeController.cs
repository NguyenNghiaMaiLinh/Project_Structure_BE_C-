using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Core.Service;
using MyApp.Core.ViewModel;
using MyApp.Core.ViewModel.ViewPage;
using MyApp_API.Handler;
using System;

namespace MyApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RecipeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRecipeService _recipeService;

        public RecipeController(IServiceProvider serviceProvider)
        {
            _recipeService = serviceProvider.GetRequiredService<IRecipeService>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
        
        }

        #region Get All Recipe By Author
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns>PagingResult<RecipeViewPage>></returns>
        /// <author>Linhnnm</author>
        [HttpGet("getAllRecipebByAuthor")]
        public ActionResult<BaseViewModel<PagingResult<RecipeViewPage>>> getAllRecipebByAuthor()
        {

            var result = _recipeService.getAllRecipeByAuthor();

            return Ok(result);
        }

        #endregion

        #region Get All Recipe Saved
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns>PagingResult<RecipeViewPage>></returns>
        /// <author>Linhnnm</author>
        [HttpGet("getAllRecipebSaved")]
        public ActionResult<BaseViewModel<PagingResult<RecipeViewPage>>> getAllRecipebSaved()
        {

            var result = _recipeService.getAllRecipeByAuthor();

            return Ok(result);
        }

        #endregion

        #region Get All Recipe Suggestion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns>PagingResult<RecipeViewPage>></returns>
        /// <author>Linhnnm</author>
        [HttpGet("getAllRecipeSuggestion")]
        public ActionResult<BaseViewModel<PagingResult<RecipeViewPage>>> getAllRecipeSuggestion()
        {

            var result = _recipeService.getAllRecipeSuggestion();

            return Ok(result);
        }

        #endregion

        #region Get All Recipe History
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns>PagingResult<RecipeViewPage>></returns>
        /// <author>Linhnnm</author>
        [HttpGet("getAllRecipeHistory")]
        public ActionResult<BaseViewModel<PagingResult<RecipeViewPage>>> getAllRecipeHistory()
        {

            var result = _recipeService.getAllRecipeByAuthor();

            return Ok(result);
        }

        #endregion

        #region Get All Recipe Top
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns>PagingResult<RecipeViewPage>></returns>
        /// <author>Linhnnm</author>
        [HttpGet("getAllRecipeTop")]
        public ActionResult<BaseViewModel<PagingResult<RecipeViewPage>>> getAllRecipeTop()
        {

            var result = _recipeService.getAllRecipeByAuthor();

            return Ok(result);
        }

        #endregion

        #region Get Recipe By Id
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns>PagingResult<RecipeViewPage>></returns>
        /// <author>Linhnnm</author>
        [HttpGet("{id}")]
        public ActionResult<BaseViewModel<RecipeViewPage>> getCommentById(string id)
        {

            var result = _recipeService.getRecipeById(id);

            return Ok(result);
        }

        #endregion

        #region create
        /// <summary>
        /// create
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <author>Linhnnm</author>
        [HttpPost]
        public ActionResult<BaseViewModel<RecipeViewPage>> create([FromBody]RecipeCreateViewPage request)
        {

            var result = _recipeService.create(request);
            return Ok(result);
        }

        #endregion

        #region update
        /// <summary>
        /// update
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <author>Linhnnm</author>
        [HttpPut]
        public ActionResult<BaseViewModel<RecipeViewPage>> update([FromBody]RecipeUpdateViewPage request)
        {

            var result = _recipeService.update(request);

            return Ok(result);
        }

        #endregion

        #region delete
        /// <summary>
        /// delete
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <author>Linhnnm</author>
        [HttpDelete("{id}")]
        public ActionResult<BaseViewModel<bool>> delete(string id)
        {

            var result = _recipeService.delete(id);

            return Ok(result);
        }

        #endregion
    }
}