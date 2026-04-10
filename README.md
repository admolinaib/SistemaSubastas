# 🛒 Sistema de Subastas - Supermercado

Aplicación de escritorio en C# (Windows Forms) para gestionar subastas 
de productos en un supermercado.

## 🏗️ Arquitectura

SistemaSubastas/
├── App/
│   └── SubastaService.cs
├── Domain/
│   ├── Productos/
│   │   ├── Producto.cs (abstracta)
│   │   ├── ProductoFactory.cs (abstracta)
│   │   ├── ProductoElectronico.cs
│   │   ├── ProductoAlimenticio.cs
│   │   ├── ProductoRopa.cs
│   │   ├── ElectronicoFactory.cs
│   │   ├── AlimenticioFactory.cs
│   │   └── RopaFactory.cs
│   ├── Subastas/
│   │   ├── IStrategySubasta.cs
│   │   ├── Subasta.cs
│   │   ├── SubastaAscendente.cs
│   │   ├── SubastaDescendente.cs
│   │   └── SubastaCerrada.cs
│   └── Usuarios/
│       ├── Usuario.cs (abstracta)
│       ├── Comprador.cs
│       └── Espectador.cs
├── Form1.cs
└── Program.cs

## 🎯 Patrones de Diseño

- **Strategy** → Lógica de cada tipo de subasta
- **Factory Method** → Creación de productos por categoría

## 📋 Tipos de Subasta

| Tipo | Comportamiento |
|---|---|
| Ascendente | Las ofertas deben superar la anterior |
| Descendente | El precio baja cada segundo hasta que alguien acepta |
| Cerrada | Ofertas en secreto, gana la más alta al cerrar |

## 💰 Categorías de Producto

| Categoría | Regla de precio |
|---|---|
| Electrónico | +10% por garantía |
| Alimenticio | -15% si está cerca de caducidad |
| Ropa | -20% si está en liquidación |

## ⚙️ Requisitos

- .NET Framework 4.7.2 o superior
- Visual Studio 2019/2022
- Windows OS

## 🚀 Cómo ejecutar

1. Clonar el repositorio
2. Abrir `SistemaSubastas.sln` en Visual Studio
3. Compilar y ejecutar (F5)
