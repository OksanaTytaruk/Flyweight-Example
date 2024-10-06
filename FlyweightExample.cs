using System;
using System.Collections.Generic;

// Легковаговик
public interface ICharacter
{
    void Display(int x, int y);
}

// Конкретний легковаговик
public class Character : ICharacter
{
    private char _symbol;
    private string _font;
    private int _size;

    public Character(char symbol, string font, int size)
    {
        _symbol = symbol;
        _font = font;
        _size = size;
    }

    public void Display(int x, int y)
    {
        Console.WriteLine($"Character: {_symbol}, Font: {_font}, Size: {_size} at ({x}, {y})");
    }
}

// Фабрика легковаговиків
public class CharacterFactory
{
    private Dictionary<char, ICharacter> _characters = new Dictionary<char, ICharacter>();

    public ICharacter GetCharacter(char symbol, string font, int size)
    {
        if (!_characters.ContainsKey(symbol))
        {
            _characters[symbol] = new Character(symbol, font, size);
        }
        return _characters[symbol];
    }
}

// Клієнтський код
class Program
{
    static void Main(string[] args)
    {
        CharacterFactory factory = new CharacterFactory();

        ICharacter a = factory.GetCharacter('A', "Arial", 12);
        ICharacter b = factory.GetCharacter('B', "Arial", 12);
        ICharacter c = factory.GetCharacter('C', "Arial", 12);
        ICharacter a2 = factory.GetCharacter('A', "Arial", 12); // Відновлюємо існуючий легковаговик

        a.Display(0, 0);
        b.Display(1, 0);
        c.Display(2, 0);
        a2.Display(0, 1); // Використовуємо існуючий легковаговик
    }
}
