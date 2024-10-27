﻿using AutoMapper;
using BusinessLayer.Services.Abstractions;
using DtoLayer.Dtos.SeansDtos;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MyWalletUI.Controllers
{

    public class SeansController : Controller
    {
        private readonly ISeansService _seansService;
        private readonly IActivityService _activityService;
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;


        public SeansController(ISeansService seansService, IActivityService activityService, ICustomerService customerService, IMapper mapper)
        {
            _seansService = seansService;
            _activityService = activityService;
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var activities = await _activityService.GetAllActivities();
            var customers = await _customerService.GetAllActiveCustomers();
            return View(new CreateSeansDto { Activities = activities, Customers = customers });

        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateSeansDto createSeansDto)
        {
            await _seansService.CreateSeansAsync(createSeansDto);
            return Redirect($"/Customer/Details/{createSeansDto.CustomerId}");
        }

        public async Task<IActionResult> Delete(int id, int customerId)
        {
            await _seansService.DeleteSeansAsync(id);
            return Redirect($"/Customer/Details/{customerId}");
        }
        public async Task<IActionResult> Active(int id, int customerId)
        {
            await _seansService.ActiveSeansAsync(id);
            return Redirect($"/Customer/Details/{customerId}");
        }
        public async Task<IActionResult> Passive(int id, int customerId)
        {
            await _seansService.PassiveSeansAsync(id);
            return Redirect($"/Customer/Details/{customerId}");
        }
    }
}

