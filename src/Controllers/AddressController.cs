using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using src.Entity;

namespace src.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController] //Adderss
    public class AddressController : ControllerBase
    {
        /*  private List<Address> _addresses;
  
          public AddressController()
          {
              _addresses = new List<Address>();
          }
  
          [HttpGet]
          public ActionResult GetAddresses()
          {
              return Ok(_addresses);
          }
  
          [HttpPost]
          public ActionResult AddAddress(Address newAddress)
          {
              _addresses.Add(newAddress);
              return Ok(newAddress);
          }
  
          
                  [HttpPut("{addressZipCode}")]
                  public ActionResult UpdateAddress(int addressId, Address updatedAddress)
                  {
                      var addressToUpdate = _addresses.FirstOrDefault(a => a.ZipCode == addressZipCode);
          
                      if (addressToUpdate == null)
                      {
                          return NotFound("Address not found");
                      }
          
                      addressToUpdate.Street = updatedAddress.Street;
                      addressToUpdate.City = updatedAddress.City;
                      addressToUpdate.County = updatedAddress.County;
                      addressToUpdate.ZipCode = updatedAddress.ZipCode;
          
                      return Ok(addressToUpdate);
                  }
         
          [HttpDelete("{addressId}")]
          public ActionResult DeleteAddress(int addressId)
          {
              var addressToDelete = _addresses.FirstOrDefault(a => a.AddressId == addressId);
  
              if (addressToDelete == null)
              {
                  return NotFound("Address not found");
              }
  
              _addresses.Remove(addressToDelete);
  
              return Ok("Address deleted successfully");
          }
          */
    }
}
