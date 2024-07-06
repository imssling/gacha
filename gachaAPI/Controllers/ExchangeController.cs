using gachaAPI.DTO;
using gachaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace gachaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeController : ControllerBase
    {

        private readonly gachaContext _context;

        public ExchangeController(gachaContext context)
        {
            _context = context;
        }


        [HttpGet("GetUserBag/{id}")]
        public async Task<IEnumerable<UserBagDTO>> GetUserBag(int id)
        {
            IEnumerable<UserBagDTO> userBagDTO = _context.Bags.Where(b => b.UserId == id).Select(b => new UserBagDTO
            {
                GachaProductId = b.GachaProductId,
                ProductPictureName = b.GachaProduct.ProductPictureName
            });

            if (userBagDTO == null)
            {
                return null;
            }

            else
            {
                return userBagDTO;
            }

        }



        // GET api/<ExchangeController>/5
        [HttpGet("GetUserName/{id}")]
        public async Task<string> GetUserName(int id)
        {
            UserInfo user = await _context.UserInfos.FindAsync(id);

            if (user == null)
            {
                return "錯誤! 找不到指定用戶!";
            }

            else
            {
                return $"{user.UserName}";
            }

        }

        // POST api/<ExchangeController>
        [HttpPost("ExchangeConfirm")]
        public async Task<string> ExchangeConfirm(bool isUserFromConfirm, bool isUserToConfirm, int intUserIdFrom, int intUserIdTo, int intGachaIdFrom, int intGachaIdTo)
        {
            if (isUserFromConfirm && isUserToConfirm)
            {
                ExchangeRecord exchangeRecord = new ExchangeRecord() 
                {
                    UserIdFrom = intUserIdFrom,
                    UserIdTo = intUserIdTo,
                    GachaIdFrom = intGachaIdTo,
                    GachaIdTo = intGachaIdTo
                };

                _context.ExchangeRecords.Add(exchangeRecord);
                await _context.SaveChangesAsync();

                return $"新增交換紀錄成功! ID : {exchangeRecord.Id}";
            }

            else
            {
                return $"新增交換紀錄失敗!";
            }


        }

  
    }
}
