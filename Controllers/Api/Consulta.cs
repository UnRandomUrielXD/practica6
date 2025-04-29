using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

[ApiController]
[Route("api/xd")]
public class InController : Controller {
    
    
    // Lista todos los vuelos que vayan de México a Canadá.
    [HttpGet("listar-mexico-canada")]
    public IActionResult ListaMexicoCanada(){
        
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Vuelos");
        var collection = db.GetCollection<Vuelos>("RentasVentas");

        List<string> pais_origenEq = new List<string>();
        pais_origenEq.Add("México");

        List<string> pais_destinoEq = new List<string>();
        pais_destinoEq.Add("Canadá");

        var filtro = Builders<Vuelos>.Filter.Eq(x => x.PaisOrigen, PaisOrigen, y => y.PaisDestino, PaisDestino);
        var list = collection.Find(filtro).ToList();
        return Ok(list);
    }
}