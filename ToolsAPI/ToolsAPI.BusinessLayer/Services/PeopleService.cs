using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolAPI.DataLayer;
using ToolAPI.DataLayer.Entities;
using ToolsAPi.Core.Models;

namespace ToolsAPI.BusinessLayer.Services
{
    public class PeopleService : IPeopleService
    {
        private readonly IDataContext dataContext;
        private readonly IMapper mapper;

        public PeopleService(IDataContext dataContext, IMapper mapper)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<PersonViewModel>> GetListOfPeople(string filter)
        {
            var query = dataContext.GetData<Person>();
            if (!string.IsNullOrEmpty(filter))
            {
                query = query.Where(p => p.Name.Contains(filter));
            };

            //var peopleDb = await query.ToListAsync();
            //return mapper.Map<IEnumerable<PersonViewModel>>(peopleDb);

            var people = await query.ProjectTo<PersonViewModel>(mapper.ConfigurationProvider)
                .ToListAsync();

            return people;

            //var people = await query.ToListAsync();       
            //return people.Select(p => new PersonViewModel
            //{
            //    Name = p.Name, Country = p.Country, Id = p.Id
            //});
        }
    }
}
