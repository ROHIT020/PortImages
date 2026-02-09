using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc; 
using PORTIMAGES.Application.Ship.DTOs;
using PORTIMAGES.Application.Ship.Interfaces;
using System.Security.Claims;

namespace PORTIMAGES.Web.Controllers.Admin
{  
    [Authorize(Roles = "Admin,Staff")]
    public class ShipController : Controller
    {
        private readonly IShipRepository _shipRepository;
        public ShipController(IShipRepository shipRepository)
        {
            this._shipRepository = shipRepository;
        }
        #region ShipMaster
        public IActionResult ShipMaster()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddShip([FromBody] ShipRequestDTO request)
        {
            request.CreatedBy = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var result = await _shipRepository.AddShipAsync(request);
            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateShip([FromBody] ShipRequestDTO request)
        {
            request.UpdatedBy = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);            
            var result = await _shipRepository.UpdateShipAsync(request);
            return Json(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetShipById(int ID)
        { 
            var response = await _shipRepository.GetShipByIdAsync(ID);
            return Json(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetShipList()
        { 
            var response = await _shipRepository.GetShipListAsync();
            return Json(response);
        }

        public async Task<IActionResult> DeleteShip(int Id)
        {
            int DeletedBy = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var result = await _shipRepository.DeleteShipAsync(Id, DeletedBy);
            return Json(result);
        }

        #endregion 
    }
}
