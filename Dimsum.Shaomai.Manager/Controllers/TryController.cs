using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dimsum.Shaomai.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Dimsum.Shaomai.Manager.Controllers
{
    public class TryController : Controller
    {
        private readonly ILogger<TryController> _logger;

        public TryController(ILogger<TryController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Rsa()
        {
            /*
            var rsaInfo = StringUtils.CreateRSAKey();
            _logger.LogInformation($"RSA.PublicKey = {rsaInfo.publicKey}");
            _logger.LogInformation($"RSA.PrivateKey = {rsaInfo.privateKey}");
            _logger.LogInformation($"RSA.Modulus = {rsaInfo.modulus}");
            _logger.LogInformation($"RSA.Exponent = {rsaInfo.exponent}");

            var wait2Encrypt = "Hello world";
            _logger.LogInformation($"String waiting for encrypt = {wait2Encrypt}");

            var encryptString = StringUtils.RSAEncrypt(rsaInfo.publicKey, wait2Encrypt);
            _logger.LogInformation($"Encrypt string = {encryptString}");

            var decryptString = StringUtils.RSADecrypt(rsaInfo.privateKey, encryptString);
            _logger.LogInformation($"Decrypt string = {decryptString}");

            return Json(new {rsaInfo.publicKey});
            */
            var rsaInfo = StringUtils.RSAInfoByPKCS8();
            _logger.LogInformation($"RSA.PublicKey = {rsaInfo.PublicKey}");
            _logger.LogInformation($"RSA.PrivateKey = {rsaInfo.privateKey}");

            var wait2Encrypt = "Hello world";
            _logger.LogInformation($"String waiting for encrypt = {wait2Encrypt}");

            var encryptString = StringUtils.EncryptRSA(rsaInfo.PublicKey, wait2Encrypt);
            _logger.LogInformation($"Encrypt string = {encryptString}");

            var decryptString = StringUtils.DecryptRSA(rsaInfo.privateKey, encryptString);
            _logger.LogInformation($"Decrypt string = {decryptString}");

            return Json(new { rsaInfo.PublicKey });
        }
    }
}