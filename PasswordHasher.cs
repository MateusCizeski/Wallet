using BCrypt.Net;

public static class PasswordHasher {
    private const int WorkFactor = 12;
    public static string HashPassword(string password) {
        if (string.IsNullOrWhiteSpace(password)) {
            throw new ArgumentException("A senha não pode ser nula ou vazia.", nameof(password));
        }

        return BCrypt.Net.BCrypt.HashPassword(password, workFactor: WorkFactor);
    }

    public static bool VerifyPassword(string password, string hashedPassword) {
        if (string.IsNullOrWhiteSpace(password)) {
            throw new ArgumentException("A senha não pode ser nula ou vazia.", nameof(password));
        }

        if (string.IsNullOrWhiteSpace(hashedPassword)) {
            throw new ArgumentException("O hash não pode ser nulo ou vazio.", nameof(hashedPassword));
        }

        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
}
