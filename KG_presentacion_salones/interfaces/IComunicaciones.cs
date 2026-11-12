namespace KG_presentacion_salones.interfaces
{
    public interface IComunicaciones
    {
        Task<T> Ejecutar<T>(string url, object entidad);
    }
}
