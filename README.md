# Calculator Project

## Architecture Layers
- **Presentation Layer**: Handles UI logic and user interaction. Presenters mediate between the UI and the domain layer.
- **Domain Layer**: Contains business logic, use cases, and models. This layer is independent of frameworks and UI.
- **Data Layer**: Handles persistence (e.g., PlayerPrefs), serialization, and data access. Exposes services to the domain layer.

## Project Structure

```
Assets/
  Scrips/
    Features/
      Calculation/
        Domain/
          Models/         # Calculator, CalculatorData, etc.
        Interfaces/       # ICalculator, use case interfaces
        Installers/       # Lifetime scopes for DI
      CalculatorWindow/
        Presenters/       # CalculatorPresenter, LayoutPresenterBase
        Interfaces/       # ICalculatorView, view contracts
        Views/            # CalculatorView, USS styles
      Saving/
        Domain/Models/    # PlayerPrefsSavingService, CalculatorAutoSaver
        UseCases/         # Save/LoadCalculatorStateUseCase
  ...
```

## Main Components

### Domain Layer
- **Calculator**: Core model, holds current equation, results, and exposes methods to update and calculate. Notifies listeners via ISubject when state is loaded.
- **CalculatorData**: Serializable data structure for saving/loading state.
- **Use Cases**: Encapsulate business logic for calculation, saving, and loading.

### Presentation Layer
- **CalculatorPresenter**: Mediates between the view and the Calculator model. Handles user input, updates the model, and updates the view on model changes. Subscribes to Calculator's ISubject to update the input field after loading.
- **LayoutPresenterBase**: Abstract base for presenters, provides common lifecycle and DI logic.
- **ICalculatorView**: Interface for the calculator UI, exposes UI elements (input field, buttons, scroll view).

### Data Layer
- **PlayerPrefsSavingService**: Handles serialization and persistence of CalculatorData using Unity's PlayerPrefs.
- **CalculatorAutoSaver**: Orchestrates saving/loading on app start/quit, calls use cases, and triggers model updates.

## Requirements
- Unity (with UI Toolkit)
- VContainer (for DI)
- R3 (for reactive programming)
- Newtonsoft.Json (for serialization)