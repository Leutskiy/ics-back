namespace ICS.Domain.Models
{
    /// <summary>
    /// DTO профиля
    /// </summary>
    public sealed class ProfileDto
    {
        /// <summary>
        /// Аватар
        /// </summary>
        public byte[] Avatar { get; set; }

        /// <summary>
        /// Веб-страницы
        /// </summary>
        public string WebPages { get; set; }
    }
}