using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Sophon.Toolkit.Tests.Util
{
    [Trait("工具类", "RSA")]
    public class RSAUtilTest
    {
        public const string publicKey = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAyZkPFzj0oROYTkEBrxpgtkTL2y999lH37zg/eJT5gBOP0hqUnDOCUej2Sa3sMy8cXXvzJdubGI7/RIZkStAlokY12VGtsyoK9hqo3a/xqJYubQSbsFeHTn6jnmwc3zpdbFTyo3MPETdWj2MujTQpAJljWgqDWYs+LA90FsX9FbPlaCy5sF/w857JRQuIM7xAlG1Tl508TvyaGG8r7wOfRPLGtkxNLFiUxLdPjKKA8Lqp7fnAPnzMQXenKFu/155IavNR3/qhZZfzybLB+dYHdta37v6/gPC76UB1EvRkm6COveD0PGbuPc69inMo6QSy7dYEeY7458sK9xXNmqLoGwIDAQAB";

        public const string privateKey = "MIIEpAIBAAKCAQEAyZkPFzj0oROYTkEBrxpgtkTL2y999lH37zg/eJT5gBOP0hqUnDOCUej2Sa3sMy8cXXvzJdubGI7/RIZkStAlokY12VGtsyoK9hqo3a/xqJYubQSbsFeHTn6jnmwc3zpdbFTyo3MPETdWj2MujTQpAJljWgqDWYs+LA90FsX9FbPlaCy5sF/w857JRQuIM7xAlG1Tl508TvyaGG8r7wOfRPLGtkxNLFiUxLdPjKKA8Lqp7fnAPnzMQXenKFu/155IavNR3/qhZZfzybLB+dYHdta37v6/gPC76UB1EvRkm6COveD0PGbuPc69inMo6QSy7dYEeY7458sK9xXNmqLoGwIDAQABAoIBADmHciUAXd7xho8eQerELkEVVM9RuDJopcYgWQyCBskjy/D7INmKYXAaeN4BwdvBX+jVjEeLabESbYoSh+BJkdPDEW7YvibYopQke3f305B2ev0lSYCDGduui+aTl5GkSDC39R3roasaDZuRhCFLdz/yhcWWJnGRKMbOCiTNjzF3yRTf6ccJpTSJEUTq5QXiyIoIsMay+f8BxkLvo7WG8/Bafqww9FNbzHlrBRFzOGRFnYz3GXVFMMfm/lJgPQqXLVOB0d4NRbP2pvy8mQOq457KHDhY8BNjQFtM/PPl34Biy0OApyKy4mEznoxYU9UbzMCKbT2XpZdMY0qD8hZ01cECgYEA6V6tl8LGJZ3IudSA2dSSFgbzV8Me25VovocgiILlNABz3iYnne6b4L48LrME4LKsFYC005UkKAbFlzrrVaNt7YQlkkd7vQnIi/roRVluC75TR66HQiajfq9+CN1bb5BwtDoIKmjEa38hlH24r8ozAjOAh8wv6Zg9julYOssqutECgYEA3SWnVw2qtbSHU9OytO51EC16DgQ9+msQbpIvQXrPotMRYyyUQ92BklzVjA0NfVEOav9zwqIVITdw2QSzofyAZ+VrT2hTCa8A1bvaGFCFq1/YBNG2Qj3r1g/906drMQXKJ1uFou7m2w+hJTerqO2LxaOYWBMCUYyvbHbEp+KQ1ysCgYEA0wsHC75duPjm5H7zg4rEDd19RTm0dzm3vs2usyVEp/Fc12JD44Q8PVNsU4MbfyS1kMCTRuCSEQyGtgvXdNvV9rzRyWaR1VO6pDRkxwpoBYC6CZIgycbthgyoetXL8al68tGkPs3+C4St1n6XfYnq9SukKaqTDbnauZn2azz+SHECgYB1P/CANEvNOSEC7dvzF/bTE/mBkvg1XCyDI1iQtAeAgb3XQhx9+uQm8Ld8ILOFPMOTMUtz5zGiwd1AAsEm4lRGQZnqqRpVqQadS5Lvj0m/ufozW+jxKBlxDlt6q2omvLYYteqdn2KgxKGgtOp7jy6rI/iywalaCWg87p+Hj5VRrwKBgQDY/kpDDumgTTPSXR1VZFdepgQNapkmpXFQfrxLScchd1wW3K4O9oTsnaQyiW7yrKvs7munAVVMaW6LkACUF91bfiHfJPGwa/DwJWsLqVeG+8YhRsT2+EkFKDrrQLvJ7mvVRJXGT+ikAMo9Q5vwwFIqBOiBRAy671QT+29yBVw2DA==";

        [Fact]
        public void RSA_Test()
        {
            var source = "123456";
            RSAUtil rsaUtil = new RSAUtil(RSAType.RSA2, Encoding.UTF8, privateKey, publicKey);
            var ciphertext = rsaUtil.Encrypt(source);
            var plaintext = rsaUtil.Decrypt(ciphertext);
            Assert.True(plaintext == source);
        }

        [Fact]
        public void Sign_Verify_Test()
        {
            var data = "https://127.0.0.1/userId=1&timestamp=2021-02-22T12:00:00";
            RSAUtil rsaUtil = new RSAUtil(RSAType.RSA2, Encoding.UTF8, privateKey, publicKey);
            var signature = rsaUtil.Sign(data);
            var verify = rsaUtil.Verify(data, signature);

            Assert.True(verify);
        }
    }
}
