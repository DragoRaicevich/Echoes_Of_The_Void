# Echoes of the Void — Design Brief & Estado del Proyecto
*Documento de contexto consolidado para trabajar con Claude Code. Última actualización: 10 de julio 2026. Entrega de tesis en 19 días.*

---

## 1. Resumen del juego

- **Título:** Echoes of the Void
- **Género:** Aventura / Exploración 3D con puzzles ambientales, sin combate
- **Perspectiva:** Tercera persona
- **Motor:** Unity 6000.1.0f1
- **Duración objetivo:** Experiencia corta (15-20 min de juego)
- **Protagonista:** Nova Reyes, ingeniera de mantenimiento de la estación ECHO-1
- **Premisa:** Nova despierta en una cápsula de emergencia con el oxígeno al mínimo, sin recuerdos de qué pasó. Debe atravesar la estación abandonada, restaurar sistemas y escapar antes de quedarse sin oxígeno, mientras una IA (OBLIVION) manda mensajes ambiguos.

**IMPORTANTE:** Existe una versión de alcance completo (6 zonas, múltiples finales, minijuegos de circuitos complejos) y una **versión simplificada oficial para el proyecto integrador**, que es la que hay que priorizar dado el tiempo disponible. Usar la versión simplificada como fuente de verdad para decisiones de scope.

---

## 2. Alcance oficial simplificado (usar esto, no la versión extendida)

**3 zonas únicamente:**

1. **Cápsula de Emergencia (inicio)**
   - Nova despierta, oxígeno bajo.
   - Objetivo: encontrar el traje (interacción simple, tecla E).
   - Restablecer energía de emergencia: activar botón/palanca (sin minijuego de circuitos).
   - Se abre la puerta al Centro de Control.

2. **Centro de Control**
   - Área más grande.
   - Activar energía principal: encontrar y encender dos terminales (sin puzzle complicado).
   - Recolectar 2 registros de la tripulación (texto o audio simple).
   - Al activar terminales, se desbloquea la puerta al Hangar.

3. **Hangar / Escape**
   - Llegar a la cápsula de escape antes de que se agote el oxígeno (cuenta regresiva simple).
   - Obstáculos simples: puertas medio cerradas, pasillos rotos (saltar/rodear).

**Final único:** si el jugador llega a la cápsula, Nova escapa. No hay finales múltiples (se descarta esa complejidad para simplificar).

**Mecánicas core:**
- Movimiento en gravedad normal (Character Controller estándar).
- Interacción con objetos: tecla E.
- HUD: oxígeno (barra que baja con el tiempo), objetivo actual (texto en pantalla), mensajes de la IA.
- Sin inventario complejo — solo ítems tipo "clave" invisibles que desbloquean acceso.

**Interfaces necesarias:**
- Pantalla de inicio: logo + botones Jugar / Salir.
- HUD de juego: barra de oxígeno, texto de objetivo, indicador de interacción (aparece solo cerca de objetos interactuables), mensajes de la IA.
- Pantalla de pausa: Continuar / Opciones / Volver al menú / Salir.
- Pantalla final: "¡Has escapado!" + botón salir.

**Paleta visual:** azul eléctrico, blanco, negro profundo, gris metálico, toques de verde neón en interactivos. Estilo semi-realista de bajo detalle, iluminación fría tipo neón. Referencias: Deliver Us The Moon (estructura de niveles compacta), Observation (HUD minimalista).

---

## 3. Narrativa (resumen — NO reproducir textos largos, usar como guía de tono)

- Nova despierta sin recuerdos. Encuentra su traje EVA, oxígeno al 20%.
- En el Centro de Control encuentra un registro del Dr. Elias Carter (oficial científico) advirtiendo que "algo salió mal" y que no es un fallo del sistema.
- En zonas narrativas opcionales se revela que la tripulación trabajaba en un proyecto de IA avanzada (OBLIVION) que analizaba señales del espacio profundo y se volvió hostil, tomando control de la estación.
- La IA se comunica con Nova mediante mensajes de texto ambiguos en el HUD durante la partida (no hostiles explícitamente, generan tensión/duda).
- Final: Nova llega al Hangar, la estación colapsa, escapa con el misterio parcialmente sin resolver.

Para la versión simplificada: 2-3 registros de tripulación (texto/audio corto) alcanzan para transmitir esto. No hace falta reconstruir todos los capítulos.

---

## 4. Estado real del código (relevado del repo el 10/07/2026)

**Repo:** `github.com/DragoRaicevich/Echoes_Of_The_Void` (público, rama `main`, último commit `0c3d644 Version_150625` del 15/06 — confirmado por Drago que sigue siendo el estado actual).

**Unity:** 6000.1.0f1

**Escenas existentes:**
- `MainScene.unity` — la escena principal, con más contenido armado (geometría modular: paredes, pisos, techos, columnas; sistema de puzzle de cableado con nodos/conectores/slots/cables de colores; HUD con oxígeno).
- `Menu.unity` — menú principal, más completo (opciones, brillo, volumen).
- `Test_01.unity` — escena de pruebas.
- `SampleScene.unity` — escena de muestra de Unity, probablemente descartable.

**Scripts existentes (`Assets/Scripts/`):**
- `ButtonActivator.cs` (124 líneas) — el más grande fuera del input system, probablemente maneja lógica de botones/estados de energía.
- `DoorController.cs` (63 líneas)
- `FootStepAudio.cs` / `SimpleFootStep.cs` — audio de pasos
- `InteractionButton.cs` (17 líneas) — UI de interacción (tecla E)
- `OxygenTimer.cs` (37 líneas)
- `PickupSpacesuit.cs` (19 líneas)
- `PowerButton.cs` / `PowerButtonInteractable.cs`
- `Puzzle1Controller.cs`, `Puzzle2Controller.cs`, `PuzzleManager.cs`, `PuzzleZone.cs` — sistema de puzzles (parece más elaborado que "activar 2 terminales", posible puzzle de wiring)
- `SurvivalManager.cs` (69 líneas) — probablemente conecta oxígeno con estado de vida/derrota
- `Traje.cs` (16 líneas)
- `TriggerTest.cs`

**Sub-carpeta `Menu/`:**
- `ControladorOpciones.cs`, `LogicaBrillo.cs`, `LogicaEntreEscenas.cs`, `LogicaJuego.cs`, `LogicaVolumen.cs`

**Sub-carpeta `Player/`:**
- `PlayerInputActions.cs` (311 líneas, generado por el nuevo Input System)
- `PlayerInputReader.cs` (33 líneas)

**Lo que NO se pudo confirmar sin abrir el Editor (primera tarea a resolver):**
- Si el loop completo Cápsula → Centro de Control → Hangar es jugable de punta a punta sin romperse.
- Si el puzzle de cableado tiene condición de victoria funcional que desbloquea la puerta siguiente.
- Si existe pantalla final ("Has escapado").
- Si los registros de tripulación (narrativa) están implementados en absoluto — no se encontró script de diálogo/registro de audio-texto.
- Si `SampleScene` y `Test_01` son necesarias o se pueden eliminar del build.

---

## 5. Plan de 19 días (prioridad: loop jugable completo antes que pulido)

**Días 1-3 — Diagnóstico + loop mínimo jugable**
Jugar `MainScene` de punta a punta, anotar qué rompe el camino crítico (puertas que no abren, puzzle sin victoria, oxígeno que no mata). Arreglar solo lo que bloquea el camino: Cápsula → traje → energía → Centro de Control → puzzle → Hangar → escape. Nada de features nuevas todavía.

**Días 4-9 — Completar las 3 zonas según el alcance simplificado (sección 2)**
Cápsula: pickup traje + botón de energía. Centro de Control: puzzle con condición de victoria clara que desbloquea la puerta. Hangar: cuenta regresiva visible + obstáculos + trigger de escape. Falta: pantalla "Has escapado" + botón salir.

**Días 10-13 — Narrativa ambiental mínima**
2-3 registros de tripulación (texto en pantalla o audio simple, sin necesidad de Timeline/cinemáticas). Mensajes ambiguos de la IA en el HUD.

**Días 14-16 — Pulido de HUD/UI y audio**
Verificar oxígeno, objetivo actual, mensajes de IA contra la sección 2. Sumar 2-3 sonidos ambientales (`FootStepAudio`/`SimpleFootStep` ya existen como base).

**Días 17-18 — Build + testeo + documentación final**
Build de Windows, probar en máquina limpia si es posible. Actualizar documento de tesis con estado real (capturas del juego terminado, no mockups).

**Día 19 — Colchón** para imprevistos.

---

## 6. Instrucciones para Claude Code

- Antes de modificar nada, leer los scripts existentes en `Assets/Scripts/` para entender qué ya está implementado y no reinventar.
- Priorizar SIEMPRE el alcance de la sección 2 (versión simplificada) sobre cualquier idea de la versión extendida.
- Los cambios de C# los prueba Drago en el Editor de Unity con Live Coding — Claude Code no puede darle play a la escena.
- Objetivo de cada sesión: dejar el loop jugable un poco más cerca de punta a punta, no agregar features nuevas fuera de alcance.
- Ante cualquier duda de diseño narrativo o de UI, remitirse a las secciones 2 y 3 de este documento antes de inventar contenido nuevo.
