using AutoMapper;
using ToolAPI.DataLayer.Entities;
using ToolsAPi.Core.Models;

namespace ToolsAPI.BusinessLayer.Mappers
{
    public class PersonMapper: Profile
    {
        public PersonMapper()
        {
            CreateMap<Person, PersonViewModel>();
        }
    }
}
