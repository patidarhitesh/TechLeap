## **Commands**

- ng new < app-name >
- cd app-name
- ng serve -o
  ( _-o for launching the browser_,
  _--port< 3000 > to change the port number_)

## **Important Angular Topics**

- Modules
- component
- Directives
- Pipes
- services - Cross cuttung concern
- Data Binding
- Routing

## Modules

All of the Angular apps that you create will be modular in form. This means that you will work with NgModules as a part of your application. When creating small web applications, you may only use one module. Every Angular app must have at least one NgModule. This is the root module and is commonly called AppModule.


## Libraries

Angular includes a collection of modules written in JavaScript and these modules form libraries within Angular, provide functionality to use in your apps. Angular libraries are noted by the @angular prefix.

This course will cover some of the common libraries in Angular and how you can install them using the node package manager (npm) and then how to import them into your code in the application. Once installed and imported, the functionality in the library is available to your application.

## Components

Angular uses the concept of a component to control aspects of your application. As an example, a component is a class that contains the logic necessary to handle an aspect of a page, called views.

Angular handles creating and destroying these components during the user interactions with your web application.

## Templates

The view for your component is defined in a template. Templates are simply HTML working with Angular on the proper rendering of the component within the application. Templates use standard HTML tags that you may already be familiar with but Angular will make tags and attributes available for the functional implementations in the template. If you have heard Angular devs talk about the moustache operator or tag, you have already heard about some of the Angular syntax that you will be using.

## Data Binding

Interactive and dynamic web applications rely on data. You might be creating an online shopping presence or perhaps reflecting statistics from polling stations in your web application. Updating the user interface when data changes, is a time consuming task with the potential for errors in the data or in the syncing of the data and UI elements.

Angular excels at data binding. You simply add binding to your markup in the templates you create and then tell Angular how the data and UI are connected. Data binding can be one-way or bidirectional.

## Directives

Directives, in essence, are commands that you give to the Angular engine. Angular will apply the instructions specified by the directive, when it renders the template, to transform the DOM in your page.

You can also have structural and attribute directives as well. They are found within element tags similar to attributes with the structural directive being responsible for altering layouts through DOM elements.

## Dependency Injection

The documentation on Angular defines dependency injection (DI) as, “a way to supply a new instance of a class with the fully-formed dependencies it requires. Most dependencies are services. Angular uses dependency injection to provide new components with the services they need.”

Essentially it is a mechanism in which the components of you Angular application resolve any dependencies related to services or components required by your component.

As you progress through the course, these concepts will be explored more fully along with examples of implementations in code to give you hands-on practice and reinforce your understanding.

### Components

- .html(UI Template)
- .css(Styling)
- .ts(Logic)
- .spec.ts(Testing)

## To create a component

- ng generate Component < component-name > || ng g c < component-name >

---

# Directives

- components
- structural --- manipulates DOM - ngfor,
  ngIf,
  ngSwitch

- attribute --- Change the appearance

## DataBinding

- String Interpolation {{.....}}
- Property Binding [.....]
- Event Binding (.....)

ex
- 1. ``` <h1 [class] ='name'> ```
- 2. ``` <h1 class = {{'name'}}> ```
Both are giving same output but if using some boolean atrinutes (like hidden), then prefer 1st.


## Types of PIPES

- uppercased
- lowercase
- number
- date
- json
- percent
- currency


### Pipe in Obseravables 
* tap
* map
* catch error 
* etc..

---

# Routes

- create route entry in routing
- ``` <a [routerLink]="['Path',< param value >]"> ```
- ActivateRoutes - Contains info abt the current route and the route tree
- Retrieve ID - call service for data

---


Interactive and dynamic web applications rely on data. You might be creating an online shopping presence or perhaps reflecting statistics from polling stations in your web application. Updating the user interface when data changes, is a time consuming task with the potential for errors in the data or in the syncing of the data and UI elements.

Angular excels at data binding. You simply add binding to your markup in the templates you create and then tell Angular how the data and UI are connected. Data binding can be one-way or bidirectional.