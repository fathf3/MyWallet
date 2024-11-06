using AutoMapper;
using BusinessLayer.Services.Abstractions;
using DtoLayer.Dtos.ActivityDtos;
using EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyWalletUI.Controllers
{
    [Authorize]
    public class ActivityController : Controller
    {
        private readonly IActivityService _activityService;
        private readonly IMapper _mapper;
        

        public ActivityController(IActivityService activityService, IMapper mapper)
        {
            _activityService = activityService;
            _mapper = mapper;

           
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var activitys = await _activityService.GetAllActivities();

            return View(activitys);

        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var activity = await _activityService.GetActivityById(id);
            var map = _mapper.Map<UpdateActivityDto>(activity);
            return View(map);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateActivityDto updateActivityDto)
        {

            await _activityService.UpdateActivityAsync(updateActivityDto);
            return RedirectToAction("Index", "Activity");


        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateActivityDto createActivityDto)
        {

            await _activityService.CreateActivityAsync(createActivityDto);

            return RedirectToAction("Index", "Activity");


        }

        public async Task<IActionResult> Delete(int id)
        {

            await _activityService.DeleteActivityAsync(id);
            return RedirectToAction("Index", "Activity");

        }
    }
}
