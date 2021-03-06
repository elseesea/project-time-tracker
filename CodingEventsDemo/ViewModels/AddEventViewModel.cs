﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CodingEventsDemo.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CodingEventsDemo.ViewModels
{
    public class AddEventViewModel
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(500, ErrorMessage = "Description too long!")]
        public string Description { get; set; }

        [EmailAddress]
        public string ContactEmail { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public int CategoryID { get; set; }
        
        //public EventType Type { get; set; }
        public List<SelectListItem> Categories { get; set; }
        /*
                public List<SelectListItem> EventTypes { get; set;  } = new List<SelectListItem>
                {
                    new SelectListItem(EventType.Conference.ToString(), ((int)EventType.Conference).ToString()),
                    new SelectListItem(EventType.Meetup.ToString(), ((int)EventType.Meetup).ToString()),
                    new SelectListItem(EventType.Social.ToString(), ((int)EventType.Social).ToString()),
                    new SelectListItem(EventType.Workshop.ToString(), ((int)EventType.Workshop).ToString())
                };
        */
        public AddEventViewModel(List<EventCategory> categories)
        {
            Categories = new List<SelectListItem>();

            foreach (var category in categories)
            {
                Categories.Add(new SelectListItem
                {
                    Value = category.Id.ToString(),
                    Text = category.Name
                });
            }
        }

        public AddEventViewModel()
        {
        }
    } // class
} // namespace
