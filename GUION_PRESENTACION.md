# 📋 GUION DE PRESENTACIÓN - SISTEMA MVC DE GESTIÓN DE REPARACIONES

## INTRODUCCIÓN

Buenos días/tardes. Hoy les presento mi proyecto del **Ejercicio de Repaso en Clase** sobre la temática de **MVC (Modelo – Vista – Controlador)**.

El objetivo de esta actividad era crear un aplicativo completo que implementara la arquitectura MVC para la **gestión de reparaciones de electrodomésticos**, manejando cuatro entidades principales: Clientes, Técnicos, Electrodomésticos y Reparaciones.

---

## 📊 ANÁLISIS DE REQUISITOS

Partiendo del diagrama de entidades proporcionado, identifiqué los siguientes requisitos:

### **Entidades a gestionar:**

1. **CLIENTE**
   - Nombre
   - Apellidos
   - DNI
   - Dirección
   - Teléfono

2. **TÉCNICO**
   - Nombre
   - Apellidos
   - NIF
   - Móvil

3. **ELECTRODOMÉSTICO**
   - Tipo
   - Modelo
   - Precio

4. **REPARACIÓN**
   - Descripción
   - Fecha
   - Hora
   - Coste
   - Garantía

### **Funcionalidades requeridas:**
- Crear registros (formularios Create)
- Visualizar registros (vistas Index y Details)
- Editar registros (formularios Edit)
- Eliminar registros (confirmación Delete)
- Interfaz de usuario clara y accesible

---

## 🏗️ ARQUITECTURA MVC IMPLEMENTADA

La arquitectura **Modelo-Vista-Controlador** se organizó de la siguiente manera:

### **1. MODELOS (Capa de Datos)**

Cada modelo representa una entidad del dominio con sus propiedades:

```
Models/
├── Cliente.cs
│   ├── ClienteId (PK)
│   ├── Nombre
│   ├── Apellidos
│   ├── DNI
│   ├── Dirección
│   └── Teléfono
│
├── Técnico.cs
│   ├── TecnicoId (PK)
│   ├── Nombre
│   ├── Apellidos
│   ├── NIF
│   └── Móvil
│
├── Electrodoméstico.cs
│   ├── ElectrodomesticoId (PK)
│   ├── Tipo
│   ├── Modelo
│   └── Precio
│
└── Reparación.cs
	├── Id (PK)
	├── Descripción
	├── Fecha
	├── Hora
	├── Coste
	└── Garantía
```

**Importancia:** Los modelos encapsulan la lógica de datos y representan la estructura de la base de datos.

### **2. CONTROLADORES (Capa de Control)**

Cada controlador gestiona las acciones CRUD para su entidad:

```
Controllers/
├── HomeController.cs
│   └── Index() - Página de inicio
│
├── ClienteController.cs
│   ├── Index() - Listar todos los clientes
│   ├── Details(id) - Ver detalles de un cliente
│   ├── Create() GET - Mostrar formulario
│   ├── Create() POST - Guardar nuevo cliente
│   ├── Edit(id) GET - Mostrar formulario de edición
│   ├── Edit(id) POST - Guardar cambios
│   ├── Delete(id) GET - Confirmar eliminación
│   └── Delete(id) POST - Eliminar cliente
│
├── TecnicoController.cs
│   └── [Acciones CRUD idénticas]
│
├── ElectrodomesticoController.cs
│   └── [Acciones CRUD idénticas]
│
└── ReparacionController.cs
	└── [Acciones CRUD idénticas]
```

**Importancia:** Los controladores reciben las peticiones del usuario, procesan la lógica empresarial y retornan las vistas aproppiadas.

### **3. VISTAS (Capa de Presentación)**

Se crearon vistas para cada operación CRUD:

```
Views/
├── Home/
│   └── Index.cshtml - Página de inicio con tarjetas de módulos
│
├── Cliente/
│   ├── Index.cshtml - Tabla de clientes
│   ├── Details.cshtml - Detalles de cliente
│   ├── Create.cshtml - Formulario crear cliente
│   └── Edit.cshtml - Formulario editar cliente
│   └── Delete.cshtml - Confirmación eliminar cliente
│
├── Técnico/
│   ├── Index.cshtml
│   ├── Details.cshtml
│   ├── Create.cshtml
│   ├── Edit.cshtml
│   └── Delete.cshtml
│
├── Electrodoméstico/
│   ├── Index.cshtml
│   ├── Details.cshtml
│   ├── Create.cshtml
│   ├── Edit.cshtml
│   └── Delete.cshtml
│
├── Reparación/
│   ├── Index.cshtml
│   ├── Details.cshtml
│   ├── Create.cshtml
│   ├── Edit.cshtml
│   └── Delete.cshtml
│
└── Shared/
	├── _Layout.cshtml - Plantilla maestra
	└── _ViewStart.cshtml - Configuración inicial
```

**Importancia:** Las vistas son la interfaz entre el usuario y la aplicación, presentando los datos de forma clara y permitiendo la interacción.

---

## 📝 IMPLEMENTACIÓN DE FORMULARIOS

### **Formularios Create y Edit**

Los formularios fueron implementados utilizando **HTML Helpers de ASP.NET MVC** para garantizar:

✅ **Vinculación automática de modelos** (Model Binding)
✅ **Validación automática**
✅ **Seguridad contra CSRF** (Anti-Forgery Tokens)
✅ **Reutilización de código** (mismo formulario para crear y editar)

#### **Ejemplo: Formulario de Cliente**

```html
@Html.BeginForm("Create", "Cliente", FormMethod.Post)
{
	<div class="form-group">
		@Html.LabelFor(m => m.Nombre)
		@Html.TextBoxFor(m => m.Nombre, new { @class = "form-control" })
	</div>

	<div class="form-group">
		@Html.LabelFor(m => m.Apellidos)
		@Html.TextBoxFor(m => m.Apellidos, new { @class = "form-control" })
	</div>

	<div class="form-group">
		@Html.LabelFor(m => m.DNI)
		@Html.TextBoxFor(m => m.DNI, new { @class = "form-control" })
	</div>

	<button type="submit" class="btn btn-primary">Guardar</button>
}
```

### **Características de los Formularios:**

| Característica | Descripción |
|---|---|
| **Campos requeridos** | Todos los campos tienen validación HTML5 |
| **Placeholders descriptivos** | Guían al usuario sobre qué ingresar |
| **Clases CSS personalizadas** | Estilos coherentes con el diseño |
| **Botones accesibles** | Con iconos y textos descriptivos |
| **Mensajes de error** | Validación en el lado del cliente |

---

## 🎨 MEJORAS IMPLEMENTADAS EN LA INTERFAZ

Además de los requisitos básicos, implementé mejoras visuales profesionales:

### **1. Estilos CSS Personalizados**

**Archivo: Content/Site.css** (399 líneas)
- Gradientes atractivos en fondos
- Animaciones fluidas en elementos interactivos
- Colores organizados por entidad

**Archivo: Content/custom.css** (Complementario)
- Estilos avanzados para detalles
- Alertas personalizadas
- Efectos de transición

### **2. Tema de Colores por Entidad**

```
👥 CLIENTES      → Rojo vibrante (#FF6B6B)
🔧 TÉCNICOS      → Turquesa (#4ECDC4)
📱 ELECTRODOMÉSTICOS → Amarillo (#FFD93D)
🛠️ REPARACIONES  → Verde menta (#95E1D3)
```

### **3. Página de Inicio (Home/Index)**

**Antes:** Diseño simple con enlaces de texto
**Después:** Tarjetas profesionales con:
- Iconos emoji descriptivos
- Descripciones claras
- Botones CTA (Call To Action) destacados
- Organización 2x2 en desktop
- Responsive para móviles

### **4. Navbar Mejorada**

- Gradiente morado elegante
- Logo con icono
- Sombras y efectos profesionales

### **5. Tablas de Datos**

- Header con gradiente colorido
- Filas interactivas con hover
- Botones de acción bien organizados (Ver, Editar, Eliminar)
- Diseño responsive

### **6. Configuración UTF-8**

Se aseguro que toda la interfaz en español se mostrara correctamente:
- Configuración en Web.config
- Codificación UTF-8 en archivos .cshtml
- Validación correcta de caracteres acentuados

---

## 💻 TECNOLOGÍAS UTILIZADAS

| Tecnología | Versión | Propósito |
|---|---|---|
| **.NET Framework** | 4.7.2 | Plataforma base |
| **ASP.NET MVC** | 5 | Framework web |
| **Razor** | 3.0 | Motor de vistas |
| **Bootstrap** | 3.x | Framework CSS |
| **CSS3** | - | Estilos personalizados |
| **HTML5** | - | Estructura del contenido |
| **C#** | 7.0 | Lenguaje de programación |

---

## ✅ FUNCIONALIDADES COMPLETADAS

### **Por cada entidad (Cliente, Técnico, Electrodoméstico, Reparación):**

| Funcionalidad | Estado |
|---|---|
| **Listar registros** (Index) | ✅ Implementado |
| **Ver detalles** (Details) | ✅ Implementado |
| **Crear registro** (Create) | ✅ Implementado con formulario |
| **Editar registro** (Edit) | ✅ Implementado con formulario |
| **Eliminar registro** (Delete) | ✅ Implementado con confirmación |
| **Navegación entre módulos** | ✅ Implementada |
| **Interfaz responsiva** | ✅ Compatible con móviles |
| **Estilos profesionales** | ✅ CSS personalizado |

---

## 📱 EXPERIENCIA DE USUARIO

### **Flujo principal:**

```
Inicio (Home/Index)
	↓
Selecciona módulo (Cliente/Técnico/Electrodoméstico/Reparación)
	↓
Ve lista de registros (Index)
	↓
Puede:
  ├─ Ver detalles (Details)
  ├─ Crear nuevo (Create)
  ├─ Editar (Edit)
  └─ Eliminar (Delete)
```

### **Características de UX:**

✨ **Navegación clara** - Menú y botones intuitivos
✨ **Feedback visual** - Efectos hover, animaciones
✨ **Iconos descriptivos** - Mejoran la comprensión
✨ **Colores organizados** - Cada módulo tiene su identidad
✨ **Formularios amigables** - Validación y ayuda al usuario
✨ **Diseño responsive** - Se adapta a cualquier dispositivo

---

## 🔒 CONSIDERACIONES DE SEGURIDAD

Aunque es una aplicación educativa, implementé prácticas de seguridad:

1. **Anti-Forgery Tokens** - Protección contra CSRF
2. **Validación de entrada** - HTML Helpers validan datos
3. **UTF-8 correcto** - Previene inyecciones de caracteres
4. **Estructura organizada** - Separación de responsabilidades (MVC)

---

## 📚 LECCIONES APRENDIDAS

Durante el desarrollo aprendí:

1. **Patrón MVC** - Cómo separar responsabilidades en capas
2. **ASP.NET MVC** - Controladores, Vistas y Modelos
3. **Razor** - Motor de plantillas dinámicas
4. **CSS personalizado** - Crear interfaces visuales atractivas
5. **Formularios en MVC** - HTML Helpers y Model Binding
6. **Codificación UTF-8** - Soporte para caracteres especiales
7. **Diseño Responsive** - Adaptabilidad a dispositivos

---

## 🚀 MEJORAS FUTURAS (Opcionales)

Posibles mejoras para versiones posteriores:

- [ ] Base de datos real (SQL Server/Entity Framework)
- [ ] Autenticación y autorización de usuarios
- [ ] Filtros y búsqueda avanzada
- [ ] Exportación de datos (PDF, Excel)
- [ ] API REST para consumo externo
- [ ] Validaciones más complejas
- [ ] Bitácora de cambios (auditoría)
- [ ] Dashboard con estadísticas

---

## ✨ CONCLUSIÓN

Este proyecto demuestra la implementación completa del patrón **Modelo-Vista-Controlador** en ASP.NET MVC 5, cumpliendo todos los requisitos de la actividad:

✅ **4 modelos** creados con sus propiedades correctas
✅ **4 controladores** con acciones CRUD completas
✅ **Formularios** funcionales para crear y editar registros
✅ **Vistas** profesionales y organizadas
✅ **Interfaz mejorada** con CSS personalizado
✅ **Experiencia de usuario** intuitiva y atractiva

La aplicación es **funcional**, **visualmente atractiva** y **fácil de usar**, demostrando la comprensión de los conceptos de MVC y las mejores prácticas de desarrollo web.

---

## 🙏 PREGUNTAS

¿Hay alguna pregunta sobre la implementación, arquitectura o funcionalidades?

---

**Fecha:** 16 de mayo de 2026
**Materia:** Desarrollo MVC
**Alumno:** [Tu nombre]
**Calificación:** Esperando evaluación ✨
