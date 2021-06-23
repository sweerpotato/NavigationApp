# NavigationApp
Solution containing a simple library, EZNavLib, for navigation between view models in WPF, and an example application using the library

# EZNavLib
A library allowing for basic navigation between objects implementing the interface `INavigatablePage` by an instance of the `Navigator` object.

## EZNavLib Documentation

### Navigator
The `Navigator` object navigates between objects implementing the interface `INavigatablePage`. It is designed with a WPF application in mind, and the view should bind to the `CurrentPage` property. The `Navigator` object needs to be constructed with the page to display first - this page is then "pushed" to the `CurrentPage` property by invoking the `OpenFirstPage` method.
The `NavigationFinished` event is raised when a page implementing the interface `ICanFinishNavigation` finishes the navigation. The `INavigatablePageResult` from the last page is then propagated to any object listening to this event.
The navigation sequence itself is defined by the objects implementing the `INavigatablePage` interface.

### INavigatablePage
The `INavigatablePage` interface requires objects implementing the interface to implement the following:
#### void Initialize(INavigatablePageResult)
This method is invoked by the `Navigator` object after the page has been constructed by the `Navigator`. The `INavigatablePageResult` argument is provided by the previous `INavigatablePage`'s `GetPageResult` method.
#### INavigatablePageResult GetPageResult()
This method is invoked by the `Navigator` when navigation to the next page is executed. It is invoked before the construction of the next `INavigatablePage` in the sequence.
The page will remain unchanged should an unhandled exception be thrown by the implementation of `GetPageResult`
#### void EventHandler CancelNavigation
The `Navigator` will revert to the first page provided at construction and clear any navigation history should this event be raised by the page.

### INavigatablePageResult
The `INavigatablePageResult` interface describes a page result yielded from the `GetPageResult` method of the object implementing the `INavigatablePage` interface.
Implementing this interface requires the implementing object to implement the following property:
#### INavigatablePage SourcePage
This property should return a reference to the page which yielded the `INavigatablePageResult` in most implementations.
#### Pre-defined page results
There are two pre-defined classes in the library implementing `INavigatablePageResult`; EmptyPageResult and DefaultPageResult.
##### EmptyPageResult
Defines an empty page result. The `SourcePage` property returns null.
##### DefaultPageResult
Defines an abstract, default and basic implementation of a page result. It provides a constructor receiving the source page as a parameter and hides the parameterless constructor. The `SourcePage` property returns the `INavigatablePage` provided at construction, unless changed by the protected set of the `SourcePage` property.

### ICanNavigate(Next|Previous)
These interfaces describe objects able to navigate to the previous page or the next page by the `Navigator` object when the corresponding event is raised.
The navigation sequence is defined by the `PageNavigatedEventArgs` provided to the `NavigateNext` event when it is raised. The sequence is dynamic, and can change depending on the `Type`s provided to the `PageNavigatedEventArgs`.
The types provided need to implement the `INavigatablePage` interface - an `ArgumentException` will be raised by the `PageNavigatedEventArgs`' constructor if they don't.
