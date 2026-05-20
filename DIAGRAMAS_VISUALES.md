# 📊 DIAGRAMA VISUAL - ARQUITECTURA MVC

## DIAGRAMA 1: COMPONENTES DEL SISTEMA MVC

```
┌──────────────────────────────────────────────────────────────┐
│                                                              │
│                    APLICACIÓN SISTEMA MVC                   │
│                                                              │
├──────────────────────────────────────────────────────────────┤
│                                                              │
│  ┌────────────┐    ┌────────────┐    ┌────────────┐         │
│  │   MODELOS  │    │CONTROLADORES│   │   VISTAS   │         │
│  ├────────────┤    ├────────────┤    ├────────────┤         │
│  │ • Cliente  │    │ • Home     │    │ • Index    │         │
│  │ • Técnico  │◄──►│ • Cliente  │◄──►│ • Details  │         │
│  │ • Electr.  │    │ • Técnico  │    │ • Create   │         │
│  │ • Reparac. │    │ • Electr.  │    │ • Edit     │         │
│  │            │    │ • Reparac. │    │ • Delete   │         │
│  └────────────┘    └────────────┘    └────────────┘         │
│   (Datos)         (Lógica Negocio)   (Presentación)         │
│                                                              │
└──────────────────────────────────────────────────────────────┘
```

## DIAGRAMA 2: FLUJO DE SOLICITUD HTTP

```
   USUARIO
	 │
	 │ 1. Hace clic en botón
	 │
	 ▼
┌─────────────────────┐
│  NAVEGADOR WEB      │
│  (Cliente)          │
│                     │
│  GET /Cliente/Index │
└────────┬────────────┘
		 │
		 │ 2. Envía solicitud HTTP
		 │
		 ▼
┌────────────────────────────────────┐
│   ASP.NET MVC (Servidor)           │
│                                    │
│  ┌──────────────────────────────┐  │
│  │  ROUTING                     │  │
│  │  /Cliente/Index              │  │
│  └────────────┬─────────────────┘  │
│               │                     │
│  ┌────────────▼─────────────────┐  │
│  │  CONTROLADOR                 │  │
│  │  ClienteController.Index()   │  │
│  │  - Leer datos del modelo     │  │
│  │  - Procesar lógica           │  │
│  └────────────┬─────────────────┘  │
│               │                     │
│  ┌────────────▼─────────────────┐  │
│  │  MODELO                      │  │
│  │  List<Cliente> clientes      │  │
│  └────────────┬─────────────────┘  │
│               │                     │
│  ┌────────────▼─────────────────┐  │
│  │  VISTA                       │  │
│  │  Index.cshtml                │  │
│  │  @foreach(var item in Model) │  │
│  │  { mostrar en tabla }        │  │
│  └────────────┬─────────────────┘  │
└────────────────┼────────────────────┘
				 │
		 3. Genera HTML
		 │
		 ▼
┌─────────────────────┐
│  NAVEGADOR WEB      │
│  (Cliente)          │
│                     │
│  Renderiza tabla    │
│  de clientes        │
└─────────────────────┘
```

## DIAGRAMA 3: ESTRUCTURA DE CARPETAS

```
SistemaMVC2/
│
├── 📁 Models/
│   ├── Cliente.cs                    (4 propiedades)
│   ├── Técnico.cs                    (4 propiedades)
│   ├── Electrodoméstico.cs           (3 propiedades)
│   └── Reparación.cs                 (5 propiedades)
│
├── 📁 Controllers/
│   ├── HomeController.cs             (Inicio del app)
│   ├── ClienteController.cs          (CRUD Clientes)
│   ├── TecnicoController.cs          (CRUD Técnicos)
│   ├── ElectrodomesticoController.cs (CRUD Electr.)
│   └── ReparacionController.cs       (CRUD Reparac.)
│
├── 📁 Views/
│   ├── 📁 Home/
│   │   └── Index.cshtml              (Página de inicio)
│   │
│   ├── 📁 Cliente/
│   │   ├── Index.cshtml              (Listar)
│   │   ├── Details.cshtml            (Ver detalles)
│   │   ├── Create.cshtml             (Crear)
│   │   ├── Edit.cshtml               (Editar)
│   │   └── Delete.cshtml             (Eliminar)
│   │
│   ├── 📁 Técnico/                   (Igual que Cliente)
│   ├── 📁 Electrodoméstico/          (Igual que Cliente)
│   ├── 📁 Reparación/                (Igual que Cliente)
│   │
│   └── 📁 Shared/
│       ├── _Layout.cshtml            (Plantilla maestra)
│       └── _ViewStart.cshtml         (Config inicial)
│
├── 📁 Content/
│   ├── Site.css                      (335 líneas - estilos principales)
│   ├── custom.css                    (Estilos adicionales)
│   └── bootstrap.min.css             (Framework CSS)
│
├── 📁 Scripts/
│   ├── jquery-1.10.2.min.js
│   ├── bootstrap.min.js
│   └── modernizr-2.6.2.js
│
├── Web.config                         (Configuración)
└── Global.asax                        (Config aplicación)
```

## DIAGRAMA 4: CICLO CRUD POR ENTIDAD

```
					┌─────────────────────────┐
					│   Listado (INDEX)       │
					│  [Tabla de registros]   │
					└────────┬────────────────┘
							 │
				┌────────────┼────────────┐
				│            │            │
				▼            ▼            ▼
		┌──────────────┐ ┌────────────┐ ┌──────────────┐
		│   Ver        │ │  Crear     │ │   Editar     │
		│  Details     │ │  CREATE    │ │   EDIT       │
		│              │ │            │ │              │
		│ - Muestra    │ │ - Form     │ │ - Form Pre   │
		│   todos los  │ │   vacío    │ │   -llenado   │
		│   campos     │ │ - Usuario  │ │ - Usuario    │
		│            │ │   ingresa  │ │   modifica   │
		│            │ │   datos    │ │ - Guardar    │
		│ - Volver    │ │ - Guardar  │ │              │
		│   a index   │ │            │ │ - Volver     │
		└──────────────┘ └────────────┘ └──────────────┘
				│            │            │
				└────────────┼────────────┘
							 │
					┌────────▼─────────┐
					│   Eliminar       │
					│   DELETE         │
					│                  │
					│ - Confirmación   │
					│ - Borrar datos   │
					│ - Volver a index │
					└────────┬─────────┘
							 │
					┌────────▼────────────┐
					│  Volver a LIST      │
					│ (Index actualizado) │
					└─────────────────────┘
```

## DIAGRAMA 5: COLORES POR MÓDULO

```
┌─────────────────────────────────────────────────────────┐
│                MÓDULOS Y COLORES                        │
├─────────────────────────────────────────────────────────┤
│                                                         │
│  👥 CLIENTES                                           │
│  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░    │
│  Color: #FF6B6B (Rojo vibrante)                       │
│  Acciones: Crear, Listar, Ver, Editar, Eliminar     │
│                                                         │
│  🔧 TÉCNICOS                                           │
│  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░    │
│  Color: #4ECDC4 (Turquesa)                            │
│  Acciones: Crear, Listar, Ver, Editar, Eliminar     │
│                                                         │
│  📱 ELECTRODOMÉSTICOS                                  │
│  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░    │
│  Color: #FFD93D (Amarillo)                            │
│  Acciones: Crear, Listar, Ver, Editar, Eliminar     │
│                                                         │
│  🛠️ REPARACIONES                                       │
│  ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░    │
│  Color: #95E1D3 (Verde menta)                         │
│  Acciones: Crear, Listar, Ver, Editar, Eliminar     │
│                                                         │
└─────────────────────────────────────────────────────────┘
```

## DIAGRAMA 6: ACCIONES CRUD POR CONTROLADOR

```
┌────────────────────────────────────────────────────────────────┐
│              ACCIONES EN EL CONTROLADOR                        │
├────────────────────────────────────────────────────────────────┤
│                                                                │
│  ClienteController.cs (y similar para otros)                  │
│                                                                │
│  ▼ GET Request                                                │
│  ┌─────────────────────────────────────────────────────────┐ │
│  │ public ActionResult Index()                             │ │
│  │ {                                                       │ │
│  │     List<Cliente> clientes = new List<Cliente>(...);   │ │
│  │     return View(clientes);  ◄── Pasa datos a vista     │ │
│  │ }                                                       │ │
│  └─────────────────────────────────────────────────────────┘ │
│                                                                │
│  ▼ GET Request                                                │
│  ┌─────────────────────────────────────────────────────────┐ │
│  │ public ActionResult Details(int id)                    │ │
│  │ {                                                       │ │
│  │     Cliente cliente = clientes.Find(x => x.Id == id);  │ │
│  │     return View(cliente);                              │ │
│  │ }                                                       │ │
│  └─────────────────────────────────────────────────────────┘ │
│                                                                │
│  ▼ GET Request (Mostrar formulario vacío)                    │
│  ┌─────────────────────────────────────────────────────────┐ │
│  │ public ActionResult Create()                            │ │
│  │ {                                                       │ │
│  │     return View();  ◄── Formulario vacío              │ │
│  │ }                                                       │ │
│  └─────────────────────────────────────────────────────────┘ │
│                                                                │
│  ▼ POST Request (Guardar datos del formulario)               │
│  ┌─────────────────────────────────────────────────────────┐ │
│  │ [HttpPost]                                              │ │
│  │ public ActionResult Create(Cliente cliente)             │ │
│  │ {                                                       │ │
│  │     lista.Add(cliente);  ◄── Agregar a lista          │ │
│  │     return RedirectToAction("Index");  ◄── Redirigir  │ │
│  │ }                                                       │ │
│  └─────────────────────────────────────────────────────────┘ │
│                                                                │
│  ▼ GET Request (Mostrar formulario con datos)                │
│  ┌─────────────────────────────────────────────────────────┐ │
│  │ public ActionResult Edit(int id)                        │ │
│  │ {                                                       │ │
│  │     Cliente cliente = lista.Find(x => x.Id == id);     │ │
│  │     return View(cliente);  ◄── Datos pre-llenados    │ │
│  │ }                                                       │ │
│  └─────────────────────────────────────────────────────────┘ │
│                                                                │
│  ▼ POST Request (Guardar cambios)                             │
│  ┌─────────────────────────────────────────────────────────┐ │
│  │ [HttpPost]                                              │ │
│  │ public ActionResult Edit(Cliente cliente)               │ │
│  │ {                                                       │ │
│  │     Cliente cliente = lista.Find(x => x.Id == id);     │ │
│  │     cliente.Nombre = cliente.Nombre; // etc            │ │
│  │     return RedirectToAction("Index");                  │ │
│  │ }                                                       │ │
│  └─────────────────────────────────────────────────────────┘ │
│                                                                │
│  ▼ GET Request (Pedir confirmación)                           │
│  ┌─────────────────────────────────────────────────────────┐ │
│  │ public ActionResult Delete(int id)                      │ │
│  │ {                                                       │ │
│  │     Cliente cliente = lista.Find(x => x.Id == id);     │ │
│  │     return View(cliente);  ◄── Mostrar confirmación   │ │
│  │ }                                                       │ │
│  └─────────────────────────────────────────────────────────┘ │
│                                                                │
│  ▼ POST Request (Eliminar)                                    │
│  ┌─────────────────────────────────────────────────────────┐ │
│  │ [HttpPost]                                              │ │
│  │ public ActionResult Delete(int id)                      │ │
│  │ {                                                       │ │
│  │     Cliente cliente = lista.Find(x => x.Id == id);     │ │
│  │     lista.Remove(cliente);  ◄── Eliminar de lista     │ │
│  │     return RedirectToAction("Index");                  │ │
│  │ }                                                       │ │
│  └─────────────────────────────────────────────────────────┘ │
│                                                                │
└────────────────────────────────────────────────────────────────┘
```

## DIAGRAMA 7: ESTRUCTURA DE UNA VISTA

```
┌──────────────────────────────────────────────────────────┐
│         ESTRUCTURA DE VISTA CSHTML                       │
├──────────────────────────────────────────────────────────┤
│                                                          │
│  @model List<Cliente>          ◄── Tipo de modelo      │
│                                                          │
│  @{                                                      │
│      ViewBag.Title = "Clientes";  ◄── Título página   │
│  }                                                       │
│                                                          │
│  <h2>Lista de Clientes</h2>                            │
│                                                          │
│  <table>                                                 │
│      <thead>                                             │
│          <tr>                                            │
│              <th>Nombre</th>                             │
│              <th>DNI</th>                                │
│              <th>Acciones</th>                           │
│          </tr>                                           │
│      </thead>                                            │
│      <tbody>                                             │
│          @foreach(var item in Model)  ◄── Loop datos   │
│          {                                               │
│              <tr>                                        │
│                  <td>@item.Nombre</td>                   │
│                  <td>@item.DNI</td>                      │
│                  <td>                                    │
│                      @Html.ActionLink("Ver",            │
│                          "Details", new {id = ...})     │
│                      @Html.ActionLink("Editar",         │
│                          "Edit", new {id = ...})        │
│                  </td>                                   │
│              </tr>                                       │
│          }                                               │
│      </tbody>                                            │
│  </table>                                                │
│                                                          │
└──────────────────────────────────────────────────────────┘
```

---

## RESUMEN VISUAL

### Navegación del Usuario

```
	 INICIO (Home/Index)
		   │
	┌──────┼──────┐
	│      │      │
	▼      ▼      ▼
Clientes Técnicos Electrodomésticos
	│      │      │
	▼      ▼      ▼
[INDEX] [INDEX] [INDEX]
	│      │      │
	├─►[DETAILS]
	├─►[CREATE]
	├─►[EDIT]
	└─►[DELETE]
```

### Interacción Usuario-Sistema

```
Usuario        Navegador       Servidor (ASP.NET MVC)
   │               │                        │
   │─Hace clic─────►│                        │
   │               │─HTTP GET────────────────►│
   │               │                         │
   │               │◄──HTML (Formulario)─────│
   │               │                        │
   │─Completa──────►│                        │
   │  formulario    │─HTTP POST────────────►│
   │               │ (datos del formulario) │
   │               │                        │
   │               │◄──Redirect─────────────│
   │               │ (a /Index)             │
   │               │                        │
   │               │─HTTP GET────────────────►│
   │               │                         │
   │               │◄──HTML (Lista actualizada)│
   │◄──Actualizado──│                        │
```
