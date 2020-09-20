using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChangeLog.Model.Log;
using ChangeLog.Service.Log;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChangeLog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChangeLogController : ControllerBase
    {
        private readonly IChangeLogService _changeLogService;

        public ChangeLogController(IChangeLogService changeLogService)
        {
            _changeLogService = changeLogService;
        }

        [Authorize]
        [HttpGet]
        public List<ChangeLogModel> Get()
        {
            return _changeLogService.Get();
        }

        [Authorize]
        [HttpPost]
        public void Add(ChangeLogModel changeLogModel)
        {
            _changeLogService.Add(changeLogModel);
        }

        [Authorize]
        [HttpPut]
        public void Update(ChangeLogModel changeLogModel)
        {
            _changeLogService.Update(changeLogModel);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public void Update([FromRoute] int id)
        {
            _changeLogService.Delete(id);
        }
    }
}
