using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMatematicas.Controllers
{
    public class Modelo {
        public int Numero1 { get; set; }
        public int Numero2 { get; set; }
    }

    public class Respuesta
    {
        public int aleatorio { get; set; }
    }

    public class RespuestaLetraAleatoria
    {
        public char letra { get; set; }
    }




    [Route("api/[controller]")]
    [ApiController]
    public class OperacionesController : ControllerBase
    {
        [HttpGet]
        public int Addition(int a, int b)
        {
            return a + b;
        }

        [HttpPost]
        [Route("Suma")]
        public int Suma([FromBody] Modelo numeros)
        {
            return (numeros.Numero1 + numeros.Numero2);
        }

        [HttpPost]
        [Route("Mult")]
        public int Mult([FromBody] Modelo numeros)
        {
            return (numeros.Numero1 * numeros.Numero2);
        }


        [HttpGet]
        [Route("Rand")]
        public Respuesta Aleatorio()
        {
            Respuesta respuesta = new Respuesta();
            Random r = new Random();
            respuesta.aleatorio = r.Next(0, 101);
            return respuesta;
        }

        [HttpPost]
        [Route("RandEspec")]
        public Respuesta AleatoriotConRago([FromBody] Modelo numeros)
        {

            Respuesta respuesta = new Respuesta();
            Random r = new Random();
            respuesta.aleatorio = (r.Next(numeros.Numero1, (numeros.Numero2 + 1)));

            return respuesta;
        }

        [HttpGet]
        [Route("letraa")]
        public RespuestaLetraAleatoria letra()
        {
            RespuestaLetraAleatoria respuesta = new RespuestaLetraAleatoria();
            Random r = new Random();
            int numero = r.Next(26);
            char letraGenerada = (char)(((int)'A') + numero);
            respuesta.letra = letraGenerada;
            return respuesta;
        }




    }
}
