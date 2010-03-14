using System;
using System.DHTML;

///<summary>
///Automatically generated jquery to script# code by Bjarte Djuvik Næss, www.bjarte.com
///<summary>
namespace Jquery
{
    [Imported]
    [IgnoreNamespace]
    public delegate bool EachCallback(int index, DOMElement value);

    [Imported]
    [IgnoreNamespace]
    public delegate Object BasicCallback(Object obj1, Object obj2);

    [GlobalMethods]
    [IgnoreNamespace]
    [Imported]
    public static partial class JQueryProxy
    {
        [PreserveCase]
        public static JQuery jQuery(string exp)
        {
            return null;
        }

        [PreserveCase]
        public static JQuery jQuery(DOMElement elm)
        {
            return null;
        }
    }

    [Imported]
    public class Bounds
    {
        [IntrinsicProperty]
        public int Top { get { return 0; } }

        [IntrinsicProperty]
        public int Left { get { return 0; } }

    }

    [Imported]
    public partial class JQuery
    {

        public JQuery Slider(Dictionary options){ return null; }

        public JQuery Slider(string action, string option, Object value) { return null; }

        public Bounds position() { return null; }

        public Bounds offset() { return null; }

        [PreserveCase]
        public JQuery flash(Dictionary options) { return null; }
        //methods goes here
        ///<summary>The current version of jQuery.</summary>
        [PreserveCase]
        public String jquery() { return null; }

        ///<summary>The number of elements currently matched. The size function will return the same value.</summary>
        [PreserveCase]
        public int length() { return 0; }

        ///<summary>
        ///      Get the number of elements currently matched. This returns the same
        ///      number as the 'length' property of the jQuery object.
        ///    </summary>
        [PreserveCase]
        public int size() { return 0; }

        ///<summary>
        ///      Access all matched DOM elements. This serves as a backwards-compatible
        ///      way of accessing all matched elements (other than the jQuery object
        ///      itself, which is, in fact, an array of elements).
        ///
        ///      It is useful if you need to operate on the DOM elements themselves instead of using built-in jQuery functions.
        ///    </summary>
        [PreserveCase]
        public DOMElement[] get() { return null; }

        ///<summary>
        ///      Access a single matched DOM element at a specified index in the matched set.
        ///      This allows you to extract the actual DOM element and operate on it
        ///      directly without necessarily using jQuery functionality on it.
        ///    </summary>
        [PreserveCase]
        public DOMElement get(int num) { return null; }

        ///<summary>
        ///      Set the jQuery object to an array of elements, while maintaining
        ///      the stack.
        ///    </summary>
        [PreserveCase]
        public JQuery pushStack(DOMElement[] elems) { return null; }

        ///<summary>
        ///      Set the jQuery object to an array of elements. This operation is
        ///      completely destructive - be sure to use .pushStack() if you wish to maintain
        ///      the jQuery stack.
        ///    </summary>
        [PreserveCase]
        public JQuery setArray(DOMElement[] elems) { return null; }

        ///<summary>
        ///      Execute a function within the context of every matched element.
        ///      This means that every time the passed-in function is executed
        ///      (which is once for every element matched) the 'this' keyword
        ///      points to the specific DOM element.
        ///
        ///      Additionally, the function, when executed, is passed a single
        ///      argument representing the position of the element in the matched
        ///      set (integer, zero-index).
        ///    </summary>
        [PreserveCase]
        public JQuery each(EachCallback fn) { return null; }

        ///<summary>
        ///      Searches every matched element for the object and returns
        ///      the index of the element, if found, starting with zero.
        ///      Returns -1 if the object wasn't found.
        ///    </summary>
        [PreserveCase]
        public int index(DOMElement subject) { return 0; }

        ///<summary>
        ///      Access a property on the first matched element.
        ///      This method makes it easy to retrieve a property value
        ///      from the first matched element.
        ///
        ///      If the element does not have an attribute with such a
        ///      name, undefined is returned.
        ///    </summary>
        [PreserveCase]
        public Object attr(String name) { return null; }

        ///<summary>
        ///      Set a key/value object as properties to all matched elements.
        ///
        ///      This serves as the best way to set a large number of properties
        ///      on all matched elements.
        ///    </summary>
        [PreserveCase]
        public JQuery attr(Object properties) { return null; }

        ///<summary>
        ///      Set a single property to a value, on all matched elements.
        ///
        ///      Note that you can't set the name property of input elements in IE.
        ///      Use $(html) or .append(html) or .html(html) to create elements
        ///      on the fly including the name property.
        ///    </summary>
        [PreserveCase]
        public JQuery attr(String key, Object value) { return null; }

        ///<summary>
        ///      Set a single property to a computed value, on all matched elements.
        ///
        ///      Instead of supplying a string value as described
        ///      [[DOM/Attributes#attr.28_key.2C_value_.29|above]],
        ///      a function is provided that computes the value.
        ///    </summary>
        [PreserveCase]
        public JQuery attr(String key, BasicCallback value) { return null; }

        ///<summary>
        ///      Access a style property on the first matched element.
        ///      This method makes it easy to retrieve a style property value
        ///      from the first matched element.
        ///    </summary>
        [PreserveCase]
        public String css(String name) { return null; }

        ///<summary>
        ///      Set a key/value object as style properties to all matched elements.
        ///
        ///      This serves as the best way to set a large number of style properties
        ///      on all matched elements.
        ///    </summary>
        [PreserveCase]
        public JQuery css(Object properties) { return null; }

        ///<summary>
        ///      Set a single style property to a value, on all matched elements.
        ///      If a number is provided, it is automatically converted into a pixel value.
        ///    </summary>
        [PreserveCase]
        public JQuery css(String key, String value) { return null; }

        ///<summary>
        ///      Set a single style property to a value, on all matched elements.
        ///      If a number is provided, it is automatically converted into a pixel value.
        ///    </summary>
        [PreserveCase]
        public JQuery css(String key, int value) { return null; }

        ///<summary>
        ///      Get the text contents of all matched elements. The result is
        ///      a string that contains the combined text contents of all matched
        ///      elements. This method works on both HTML and XML documents.
        ///    </summary>
        [PreserveCase]
        public String text() { return null; }

        ///<summary>
        ///      Set the text contents of all matched elements.
        ///
        ///      Similar to html(), but escapes HTML (replace "<" and ">" with their
        ///      HTML entities).
        ///    </summary>
        [PreserveCase]
        public String text(String val) { return null; }

        ///<summary>
        ///      Wrap all matched elements with a structure of other elements.
        ///      This wrapping process is most useful for injecting additional
        ///      stucture into a document, without ruining the original semantic
        ///      qualities of a document.
        ///
        ///      This works by going through the first element
        ///      provided (which is generated, on the fly, from the provided HTML)
        ///      and finds the deepest ancestor element within its
        ///      structure - it is that element that will en-wrap everything else.
        ///
        ///      This does not work with elements that contain text. Any necessary text
        ///      must be added after the wrapping is done.
        ///    </summary>
        [PreserveCase]
        public JQuery wrap(String html) { return null; }

        ///<summary>
        ///      Wrap all matched elements with a structure of other elements.
        ///      This wrapping process is most useful for injecting additional
        ///      stucture into a document, without ruining the original semantic
        ///      qualities of a document.
        ///
        ///      This works by going through the first element
        ///      provided and finding the deepest ancestor element within its
        ///      structure - it is that element that will en-wrap everything else.
        ///
        ///      This does not work with elements that contain text. Any necessary text
        ///      must be added after the wrapping is done.
        ///    </summary>
        [PreserveCase]
        public JQuery wrap(DOMElement elem) { return null; }

        ///<summary>
        ///      Append content to the inside of every matched element.
        ///
        ///      This operation is similar to doing an appendChild to all the
        ///      specified elements, adding them into the document.
        ///    </summary>
        [PreserveCase]
        public JQuery append(Object content) { return null; }

        ///<summary>
        ///      Prepend content to the inside of every matched element.
        ///
        ///      This operation is the best way to insert elements
        ///      inside, at the beginning, of all matched elements.
        ///    </summary>
        [PreserveCase]
        public JQuery prepend(Object content) { return null; }

        ///<summary>Insert content before each of the matched elements.</summary>
        [PreserveCase]
        public JQuery before(Object content) { return null; }

        ///<summary>Insert content after each of the matched elements.</summary>
        [PreserveCase]
        public JQuery after(Object content) { return null; }

        ///<summary>
        ///      Revert the most recent 'destructive' operation, changing the set of matched elements
        ///      to its previous state (right before the destructive operation).
        ///
        ///      If there was no destructive operation before, an empty set is returned.
        ///
        ///      A 'destructive' operation is any operation that changes the set of
        ///      matched jQuery elements. These functions are: <code>add</code>,
        ///      <code>children</code>, <code>clone</code>, <code>filter</code>,
        ///      <code>find</code>, <code>not</code>, <code>next</code>,
        ///      <code>parent</code>, <code>parents</code>, <code>prev</code> and <code>siblings</code>.
        ///    </summary>
        [PreserveCase]
        public JQuery end() { return null; }

        ///<summary>
        ///      Searches for all elements that match the specified expression.
        ///      This method is a good way to find additional descendant
        ///      elements with which to process.
        ///
        ///      All searching is done using a jQuery expression. The expression can be
        ///      written using CSS 1-3 Selector syntax, or basic XPath.
        ///    </summary>
        [PreserveCase]
        public JQuery find(String expr) { return null; }

        ///<summary>
        ///      Clone matched DOM Elements and select the clones.
        ///
        ///      This is useful for moving copies of the elements to another
        ///      location in the DOM.
        ///    </summary>
        [PreserveCase]
        public JQuery clone(bool deep) { return null; }

        ///<summary>
        ///      Removes all elements from the set of matched elements that do not
        ///      match the specified expression(s). This method is used to narrow down
        ///      the results of a search.
        ///
        ///      Provide a comma-separated list of expressions to apply multiple filters at once.
        ///    </summary>
        [PreserveCase]
        public JQuery filter(String expression) { return null; }

        ///<summary>
        ///      Removes all elements from the set of matched elements that do not
        ///      pass the specified filter. This method is used to narrow down
        ///      the results of a search.
        ///    </summary>
        [PreserveCase]
        public JQuery filter(BasicCallback filter) { return null; }

        ///<summary>
        ///      Removes the specified Element from the set of matched elements. This
        ///      method is used to remove a single Element from a jQuery object.
        ///    </summary>
        [PreserveCase]
        public JQuery not(DOMElement el) { return null; }

        ///<summary>
        ///      Removes elements matching the specified expression from the set
        ///      of matched elements. This method is used to remove one or more
        ///      elements from a jQuery object.
        ///    </summary>
        [PreserveCase]
        public JQuery not(String expr) { return null; }

        ///<summary>
        ///      Removes any elements inside the array of elements from the set
        ///      of matched elements. This method is used to remove one or more
        ///      elements from a jQuery object.
        ///
        ///      Please note: the expression cannot use a reference to the
        ///      element name. See the two examples below.
        ///    </summary>
        [PreserveCase]
        public JQuery not(JQuery elems) { return null; }

        ///<summary>
        ///      Adds more elements, matched by the given expression,
        ///      to the set of matched elements.
        ///    </summary>
        [PreserveCase]
        public JQuery add(String expr) { return null; }

        ///<summary>Adds one or more Elements to the set of matched elements.</summary>
        [PreserveCase]
        public JQuery add(DOMElement elements) { return null; }

        ///<summary>Adds one or more Elements to the set of matched elements.</summary>
        [PreserveCase]
        public JQuery add(DOMElement[] elements) { return null; }

        ///<summary>
        ///      Checks the current selection against an expression and returns true,
        ///      if at least one element of the selection fits the given expression.
        ///
        ///      Does return false, if no element fits or the expression is not valid.
        ///
        ///      filter(String) is used internally, therefore all rules that apply there
        ///      apply here, too.
        ///    </summary>
        [PreserveCase]
        public bool isInExpression(String expr) { return false; }

        ///<summary>
        ///      Get the content of the value attribute of the first matched element.
        ///
        ///      Use caution when relying on this function to check the value of
        ///      multiple-select elements and checkboxes in a form. While it will
        ///      still work as intended, it may not accurately represent the value
        ///      the server will receive because these elements may send an array
        ///      of values. For more robust handling of field values, see the
        ///      [http://www.malsup.com/jquery/form/#fields fieldValue function of the Form Plugin].
        ///    </summary>
        [PreserveCase]
        public String val() { return null; }

        ///<summary>    Set the value attribute of every matched element.</summary>
        [PreserveCase]
        public JQuery val(String val) { return null; }

        ///<summary>
        ///      Get the html contents of the first matched element.
        ///      This property is not available on XML documents.
        ///    </summary>
        [PreserveCase]
        public String html() { return null; }

        ///<summary>
        ///      Set the html contents of every matched element.
        ///      This property is not available on XML documents.
        ///    </summary>
        [PreserveCase]
        public JQuery html(String val) { return null; }

        ///<summary></summary>
        [PreserveCase]
        public JQuery domManip(Object[] args, bool table, int dir, BasicCallback fn) { return null; }

        ///<summary>
        ///      Get a set of elements containing the unique parents of the matched
        ///      set of elements.
        ///
        ///      You may use an optional expression to filter the set of parent elements that will match.
        ///    </summary>
        [PreserveCase]
        public JQuery parent(String expr) { return null; }

        ///<summary>
        ///      Get a set of elements containing the unique ancestors of the matched
        ///      set of elements (except for the root element).
        ///
        ///      The matched elements can be filtered with an optional expression.
        ///    </summary>
        [PreserveCase]
        public JQuery parents(String expr) { return null; }

        ///<summary>
        ///      Get a set of elements containing the unique next siblings of each of the
        ///      matched set of elements.
        ///
        ///      It only returns the very next sibling for each element, not all
        ///      next siblings.
        ///
        ///      You may provide an optional expression to filter the match.
        ///    </summary>
        [PreserveCase]
        public JQuery next(String expr) { return null; }

        ///<summary>
        ///      Get a set of elements containing the unique previous siblings of each of the
        ///      matched set of elements.
        ///
        ///      Use an optional expression to filter the matched set.
        ///
        ///      Only the immediately previous sibling is returned, not all previous siblings.
        ///    </summary>
        [PreserveCase]
        public JQuery prev(String expr) { return null; }

        ///<summary>
        ///      Get a set of elements containing all of the unique siblings of each of the
        ///      matched set of elements.
        ///
        ///      Can be filtered with an optional expressions.
        ///    </summary>
        [PreserveCase]
        public JQuery siblings(String expr) { return null; }

        ///<summary>
        ///      Get a set of elements containing all of the unique children of each of the
        ///      matched set of elements.
        ///
        ///      This set can be filtered with an optional expression that will cause
        ///      only elements matching the selector to be collected.
        ///    </summary>
        [PreserveCase]
        public JQuery children(String expr) { return null; }

        ///<summary>
        ///      Append all of the matched elements to another, specified, set of elements.
        ///      This operation is, essentially, the reverse of doing a regular
        ///      $(A).append(B), in that instead of appending B to A, you're appending
        ///      A to B.
        ///    </summary>
        [PreserveCase]
        public JQuery appendTo(Object content) { return null; }

        ///<summary>
        ///      Prepend all of the matched elements to another, specified, set of elements.
        ///      This operation is, essentially, the reverse of doing a regular
        ///      $(A).prepend(B), in that instead of prepending B to A, you're prepending
        ///      A to B.
        ///    </summary>
        [PreserveCase]
        public JQuery prependTo(Object content) { return null; }

        ///<summary>
        ///      Insert all of the matched elements before another, specified, set of elements.
        ///      This operation is, essentially, the reverse of doing a regular
        ///      $(A).before(B), in that instead of inserting B before A, you're inserting
        ///      A before B.
        ///    </summary>
        [PreserveCase]
        public JQuery insertBefore(Object content) { return null; }

        ///<summary>
        ///      Insert all of the matched elements after another, specified, set of elements.
        ///      This operation is, essentially, the reverse of doing a regular
        ///      $(A).after(B), in that instead of inserting B after A, you're inserting
        ///      A after B.
        ///    </summary>
        [PreserveCase]
        public JQuery insertAfter(Object content) { return null; }

        ///<summary>Remove an attribute from each of the matched elements.</summary>
        [PreserveCase]
        public JQuery removeAttr(String name) { return null; }

        ///<summary>Adds the specified class(es) to each of the set of matched elements.</summary>
        [PreserveCase]
        public JQuery addClass(String cssClass) { return null; }

        ///<summary>Removes all or the specified class(es) from the set of matched elements.</summary>
        [PreserveCase]
        public JQuery removeClass(String cssClass) { return null; }

        ///<summary>
        ///      Adds the specified class if it is not present, removes it if it is
        ///      present.
        ///    </summary>
        [PreserveCase]
        public JQuery toggleClass(String cssClass) { return null; }

        ///<summary>
        ///      Removes all matched elements from the DOM. This does NOT remove them from the
        ///      jQuery object, allowing you to use the matched elements further.
        ///
        ///      Can be filtered with an optional expressions.
        ///    </summary>
        [PreserveCase]
        public JQuery remove(String expr) { return null; }

        ///<summary>Removes all child nodes from the set of matched elements.</summary>
        [PreserveCase]
        public JQuery empty() { return null; }

        ///<summary>
        ///      Reduce the set of matched elements to a single element.
        ///      The position of the element in the set of matched elements
        ///      starts at 0 and goes to length - 1.
        ///    </summary>
        [PreserveCase]
        public JQuery eq(int pos) { return null; }

        ///<summary>
        ///      Reduce the set of matched elements to all elements before a given position.
        ///      The position of the element in the set of matched elements
        ///      starts at 0 and goes to length - 1.
        ///    </summary>
        [PreserveCase]
        public JQuery lt(int pos) { return null; }

        ///<summary>
        ///      Reduce the set of matched elements to all elements after a given position.
        ///      The position of the element in the set of matched elements
        ///      starts at 0 and goes to length - 1.
        ///    </summary>
        [PreserveCase]
        public JQuery gt(int pos) { return null; }

        ///<summary>Filter the set of elements to those that contain the specified text.</summary>
        [PreserveCase]
        public JQuery contains(String str) { return null; }

        ///<summary>Get the current computed, pixel, width of the first matched element.</summary>
        [PreserveCase]
        public String width() { return null; }

        ///<summary>
        ///      Set the CSS width of every matched element. If no explicit unit
        ///      was specified (like 'em' or '%') then "px" is added to the width.
        ///    </summary>
        [PreserveCase]
        public JQuery width(String val) { return null; }

        ///<summary>
        ///      Set the CSS width of every matched element. If no explicit unit
        ///      was specified (like 'em' or '%') then "px" is added to the width.
        ///    </summary>
        [PreserveCase]
        public JQuery width(int val) { return null; }

        ///<summary>Get the current computed, pixel, height of the first matched element.</summary>
        [PreserveCase]
        public String height() { return null; }

        ///<summary>
        ///      Set the CSS height of every matched element. If no explicit unit
        ///      was specified (like 'em' or '%') then "px" is added to the width.
        ///    </summary>
        [PreserveCase]
        public JQuery height(String val) { return null; }

        ///<summary>
        ///      Set the CSS height of every matched element. If no explicit unit
        ///      was specified (like 'em' or '%') then "px" is added to the width.
        ///    </summary>
        [PreserveCase]
        public JQuery height(int val) { return null; }

        ///<summary>
        ///      Binds a handler to a particular event (like click) for each matched element.
        ///      The event handler is passed an event object that you can use to prevent
        ///      default behaviour. To stop both default action and event bubbling, your handler
        ///      has to return false.
        ///
        ///      In most cases, you can define your event handlers as anonymous functions
        ///      (see first example). In cases where that is not possible, you can pass additional
        ///      data as the second parameter (and the handler function as the third), see
        ///      second example.
        ///    </summary>
        [PreserveCase]
        public JQuery bind(String type, Object data, BasicCallback fn) { return null; }

        ///<summary>
        ///      Binds a handler to a particular event (like click) for each matched element.
        ///      The handler is executed only once for each element. Otherwise, the same rules
        ///      as described in bind() apply.
        ///      The event handler is passed an event object that you can use to prevent
        ///      default behaviour. To stop both default action and event bubbling, your handler
        ///      has to return false.
        ///
        ///      In most cases, you can define your event handlers as anonymous functions
        ///      (see first example). In cases where that is not possible, you can pass additional
        ///      data as the second paramter (and the handler function as the third), see
        ///      second example.
        ///    </summary>
        [PreserveCase]
        public JQuery one(String type, Object data, BasicCallback fn) { return null; }

        ///<summary>
        ///      The opposite of bind, removes a bound event from each of the matched
        ///      elements.
        ///
        ///      Without any arguments, all bound events are removed.
        ///
        ///      If the type is provided, all bound events of that type are removed.
        ///
        ///      If the function that was passed to bind is provided as the second argument,
        ///      only that specific event handler is removed.
        ///    </summary>
        [PreserveCase]
        public JQuery unbind(String type, BasicCallback fn) { return null; }

        ///<summary>
        ///      Trigger a type of event on every matched element. This will also cause
        ///      the default action of the browser with the same name (if one exists)
        ///      to be executed. For example, passing 'submit' to the trigger()
        ///      function will also cause the browser to submit the form. This
        ///      default action can be prevented by returning false from one of
        ///      the functions bound to the event.
        ///
        ///      You can also trigger custom events registered with bind.
        ///    </summary>
        [PreserveCase]
        public JQuery trigger(String type, Object[] data) { return null; }

        ///<summary>
        ///      Toggle between two function calls every other click.
        ///      Whenever a matched element is clicked, the first specified function
        ///      is fired, when clicked again, the second is fired. All subsequent
        ///      clicks continue to rotate through the two functions.
        ///
        ///      Use unbind("click") to remove.
        ///    </summary>
        [PreserveCase]
        public JQuery toggle(BasicCallback even, BasicCallback odd) { return null; }

        ///<summary>
        ///      A method for simulating hovering (moving the mouse on, and off,
        ///      an object). This is a custom method which provides an 'in' to a
        ///      frequent task.
        ///
        ///      Whenever the mouse cursor is moved over a matched
        ///      element, the first specified function is fired. Whenever the mouse
        ///      moves off of the element, the second specified function fires.
        ///      Additionally, checks are in place to see if the mouse is still within
        ///      the specified element itself (for example, an image inside of a div),
        ///      and if it is, it will continue to 'hover', and not move out
        ///      (a common error in using a mouseout event handler).
        ///    </summary>
        [PreserveCase]
        public JQuery hover(BasicCallback over, BasicCallback Out) { return null; }

        ///<summary>
        ///      Bind a function to be executed whenever the DOM is ready to be
        ///      traversed and manipulated. This is probably the most important
        ///      function included in the event module, as it can greatly improve
        ///      the response times of your web applications.
        ///
        ///      In a nutshell, this is a solid replacement for using window.onload,
        ///      and attaching a function to that. By using this method, your bound function
        ///      will be called the instant the DOM is ready to be read and manipulated,
        ///      which is when what 99.99% of all JavaScript code needs to run.
        ///
        ///      There is one argument passed to the ready event handler: A reference to
        ///      the jQuery function. You can name that argument whatever you like, and
        ///      can therefore stick with the $ alias without risk of naming collisions.
        ///
        ///      Please ensure you have no code in your <body> onload event handler,
        ///      otherwise $(document).ready() may not fire.
        ///
        ///      You can have as many $(document).ready events on your page as you like.
        ///      The functions are then executed in the order they were added.
        ///    </summary>
        [PreserveCase]
        public JQuery ready(BasicCallback fn) { return null; }

        ///<summary>Bind a function to the scroll event of each matched element.</summary>
        [PreserveCase]
        public JQuery scroll(BasicCallback fn) { return null; }

        ///<summary>Bind a function to the submit event of each matched element.</summary>
        [PreserveCase]
        public JQuery submit(BasicCallback fn) { return null; }

        ///<summary>
        ///      Trigger the submit event of each matched element. This causes all of the functions
        ///      that have been bound to that submit event to be executed, and calls the browser's
        ///      default submit action on the matching element(s). This default action can be prevented
        ///      by returning false from one of the functions bound to the submit event.
        ///
        ///      Note: This does not execute the submit method of the form element! If you need to
        ///      submit the form via code, you have to use the DOM method, eg. $("form")[0].submit();
        ///    </summary>
        [PreserveCase]
        public JQuery submit() { return null; }

        ///<summary>Bind a function to the focus event of each matched element.</summary>
        [PreserveCase]
        public JQuery focus(BasicCallback fn) { return null; }

        ///<summary>
        ///      Trigger the focus event of each matched element. This causes all of the functions
        ///      that have been bound to thet focus event to be executed.
        ///
        ///      Note: This does not execute the focus method of the underlying elements! If you need to
        ///      focus an element via code, you have to use the DOM method, eg. $("#myinput")[0].focus();
        ///    </summary>
        [PreserveCase]
        public JQuery focus() { return null; }

        ///<summary>Bind a function to the keydown event of each matched element.</summary>
        [PreserveCase]
        public JQuery keydown(BasicCallback fn) { return null; }

        ///<summary>Bind a function to the dblclick event of each matched element.</summary>
        [PreserveCase]
        public JQuery dblclick(BasicCallback fn) { return null; }

        ///<summary>Bind a function to the keypress event of each matched element.</summary>
        [PreserveCase]
        public JQuery keypress(BasicCallback fn) { return null; }

        ///<summary>Bind a function to the error event of each matched element.</summary>
        [PreserveCase]
        public JQuery error(BasicCallback fn) { return null; }

        ///<summary>Bind a function to the blur event of each matched element.</summary>
        [PreserveCase]
        public JQuery blur(BasicCallback fn) { return null; }

        ///<summary>
        ///      Trigger the blur event of each matched element. This causes all of the functions
        ///      that have been bound to that blur event to be executed, and calls the browser's
        ///      default blur action on the matching element(s). This default action can be prevented
        ///      by returning false from one of the functions bound to the blur event.
        ///
        ///      Note: This does not execute the blur method of the underlying elements! If you need to
        ///      blur an element via code, you have to use the DOM method, eg. $("#myinput")[0].blur();
        ///    </summary>
        [PreserveCase]
        public JQuery blur() { return null; }

        ///<summary>Bind a function to the load event of each matched element.</summary>
        [PreserveCase]
        public JQuery load(BasicCallback fn) { return null; }

        ///<summary>Bind a function to the select event of each matched element.</summary>
        [PreserveCase]
        public JQuery select(BasicCallback fn) { return null; }

        ///<summary>
        ///      Trigger the select event of each matched element. This causes all of the functions
        ///      that have been bound to that select event to be executed, and calls the browser's
        ///      default select action on the matching element(s). This default action can be prevented
        ///      by returning false from one of the functions bound to the select event.
        ///    </summary>
        [PreserveCase]
        public JQuery select() { return null; }

        ///<summary>Bind a function to the mouseup event of each matched element.</summary>
        [PreserveCase]
        public JQuery mouseup(BasicCallback fn) { return null; }

        ///<summary>Bind a function to the unload event of each matched element.</summary>
        [PreserveCase]
        public JQuery unload(BasicCallback fn) { return null; }

        ///<summary>Bind a function to the change event of each matched element.</summary>
        [PreserveCase]
        public JQuery change(BasicCallback fn) { return null; }

        ///<summary>Bind a function to the mouseout event of each matched element.</summary>
        [PreserveCase]
        public JQuery mouseout(BasicCallback fn) { return null; }

        ///<summary>Bind a function to the keyup event of each matched element.</summary>
        [PreserveCase]
        public JQuery keyup(BasicCallback fn) { return null; }

        ///<summary>Bind a function to the click event of each matched element.</summary>
        [PreserveCase]
        public JQuery click(BasicCallback fn) { return null; }

        ///<summary>
        ///      Trigger the click event of each matched element. This causes all of the functions
        ///      that have been bound to thet click event to be executed.
        ///    </summary>
        [PreserveCase]
        public JQuery click() { return null; }

        ///<summary>Bind a function to the resize event of each matched element.</summary>
        [PreserveCase]
        public JQuery resize(BasicCallback fn) { return null; }

        ///<summary>Bind a function to the mousemove event of each matched element.</summary>
        [PreserveCase]
        public JQuery mousemove(BasicCallback fn) { return null; }

        ///<summary>Bind a function to the mousedown event of each matched element.</summary>
        [PreserveCase]
        public JQuery mousedown(BasicCallback fn) { return null; }

        ///<summary>Bind a function to the mouseover event of each matched element.</summary>
        [PreserveCase]
        public JQuery mouseover(BasicCallback fn) { return null; }

        ///<summary>
        ///      Load HTML from a remote file and inject it into the DOM, only if it's
        ///      been modified by the server.
        ///    </summary>
        [PreserveCase]
        public JQuery loadIfModified(String url, Object parameters, BasicCallback callback) { return null; }

        ///<summary>
        ///      Load HTML from a remote file and inject it into the DOM.
        ///
        ///      Note: Avoid to use this to load scripts, instead use $.getScript.
        ///      IE strips script tags when there aren't any other characters in front of it.
        ///    </summary>
        [PreserveCase]
        public JQuery load(String url, Object parameters, BasicCallback callback) { return null; }

        ///<summary>
        ///      Serializes a set of input elements into a string of data.
        ///      This will serialize all given elements.
        ///
        ///      A serialization similar to the form submit of a browser is
        ///      provided by the [http://www.malsup.com/jquery/form/ Form Plugin].
        ///      It also takes multiple-selects
        ///      into account, while this method recognizes only a single option.
        ///    </summary>
        [PreserveCase]
        public String serialize() { return null; }

        ///<summary>
        ///      Evaluate all script tags inside this jQuery. If they have a src attribute,
        ///      the script is loaded, otherwise it's content is evaluated.
        ///    </summary>
        [PreserveCase]
        public JQuery evalScripts() { return null; }

        ///<summary>
        ///      Attach a function to be executed whenever an AJAX request begins
        ///      and there is none already active.
        ///    </summary>
        [PreserveCase]
        public JQuery ajaxStart(BasicCallback callback) { return null; }

        ///<summary>Attach a function to be executed whenever all AJAX requests have ended.</summary>
        [PreserveCase]
        public JQuery ajaxStop(BasicCallback callback) { return null; }

        ///<summary>
        ///      Attach a function to be executed whenever an AJAX request completes.
        ///
        ///      The XMLHttpRequest and settings used for that request are passed
        ///      as arguments to the callback.
        ///    </summary>
        [PreserveCase]
        public JQuery ajaxComplete(BasicCallback callback) { return null; }

        ///<summary>
        ///      Attach a function to be executed whenever an AJAX request completes
        ///      successfully.
        ///
        ///      The XMLHttpRequest and settings used for that request are passed
        ///      as arguments to the callback.
        ///    </summary>
        [PreserveCase]
        public JQuery ajaxSuccess(BasicCallback callback) { return null; }

        ///<summary>
        ///      Attach a function to be executed whenever an AJAX request fails.
        ///
        ///      The XMLHttpRequest and settings used for that request are passed
        ///      as arguments to the callback. A third argument, an exception object,
        ///      is passed if an exception occured while processing the request.
        ///    </summary>
        [PreserveCase]
        public JQuery ajaxError(BasicCallback callback) { return null; }

        ///<summary>
        ///      Attach a function to be executed before an AJAX request is sent.
        ///
        ///      The XMLHttpRequest and settings used for that request are passed
        ///      as arguments to the callback.
        ///    </summary>
        [PreserveCase]
        public JQuery ajaxSend(BasicCallback callback) { return null; }

        ///<summary>Displays each of the set of matched elements if they are hidden.</summary>
        [PreserveCase]
        public JQuery show() { return null; }

        ///<summary>
        ///      Show all matched elements using a graceful animation and firing an
        ///      optional callback after completion.
        ///
        ///      The height, width, and opacity of each of the matched elements
        ///      are changed dynamically according to the specified speed.
        ///    </summary>
        [PreserveCase]
        public JQuery show(String speed, BasicCallback callback) { return null; }

        ///<summary>
        ///      Show all matched elements using a graceful animation and firing an
        ///      optional callback after completion.
        ///
        ///      The height, width, and opacity of each of the matched elements
        ///      are changed dynamically according to the specified speed.
        ///    </summary>
        [PreserveCase]
        public JQuery show(int speed, BasicCallback callback) { return null; }

        ///<summary>Hides each of the set of matched elements if they are shown.</summary>
        [PreserveCase]
        public JQuery hide() { return null; }

        ///<summary>
        ///      Hide all matched elements using a graceful animation and firing an
        ///      optional callback after completion.
        ///
        ///      The height, width, and opacity of each of the matched elements
        ///      are changed dynamically according to the specified speed.
        ///    </summary>
        [PreserveCase]
        public JQuery hide(String speed, BasicCallback callback) { return null; }

        ///<summary>
        ///      Hide all matched elements using a graceful animation and firing an
        ///      optional callback after completion.
        ///
        ///      The height, width, and opacity of each of the matched elements
        ///      are changed dynamically according to the specified speed.
        ///    </summary>
        [PreserveCase]
        public JQuery hide(int speed, BasicCallback callback) { return null; }

        ///<summary>
        ///      Toggles each of the set of matched elements. If they are shown,
        ///      toggle makes them hidden. If they are hidden, toggle
        ///      makes them shown.
        ///    </summary>
        [PreserveCase]
        public JQuery toggle() { return null; }

        ///<summary>
        ///      Reveal all matched elements by adjusting their height and firing an
        ///      optional callback after completion.
        ///
        ///      Only the height is adjusted for this animation, causing all matched
        ///      elements to be revealed in a "sliding" manner.
        ///    </summary>
        [PreserveCase]
        public JQuery slideDown(String speed, BasicCallback callback) { return null; }

        ///<summary>
        ///      Reveal all matched elements by adjusting their height and firing an
        ///      optional callback after completion.
        ///
        ///      Only the height is adjusted for this animation, causing all matched
        ///      elements to be revealed in a "sliding" manner.
        ///    </summary>
        [PreserveCase]
        public JQuery slideDown(int speed, BasicCallback callback) { return null; }

        ///<summary>
        ///      Hide all matched elements by adjusting their height and firing an
        ///      optional callback after completion.
        ///
        ///      Only the height is adjusted for this animation, causing all matched
        ///      elements to be hidden in a "sliding" manner.
        ///    </summary>
        [PreserveCase]
        public JQuery slideUp(String speed, BasicCallback callback) { return null; }

        ///<summary>
        ///      Hide all matched elements by adjusting their height and firing an
        ///      optional callback after completion.
        ///
        ///      Only the height is adjusted for this animation, causing all matched
        ///      elements to be hidden in a "sliding" manner.
        ///    </summary>
        [PreserveCase]
        public JQuery slideUp(int speed, BasicCallback callback) { return null; }

        ///<summary>
        ///      Toggle the visibility of all matched elements by adjusting their height and firing an
        ///      optional callback after completion.
        ///
        ///      Only the height is adjusted for this animation, causing all matched
        ///      elements to be hidden in a "sliding" manner.
        ///    </summary>
        [PreserveCase]
        public JQuery slideToggle(String speed, BasicCallback callback) { return null; }

        ///<summary>
        ///      Toggle the visibility of all matched elements by adjusting their height and firing an
        ///      optional callback after completion.
        ///
        ///      Only the height is adjusted for this animation, causing all matched
        ///      elements to be hidden in a "sliding" manner.
        ///    </summary>
        [PreserveCase]
        public JQuery slideToggle(int speed, BasicCallback callback) { return null; }

        ///<summary>
        ///      Fade in all matched elements by adjusting their opacity and firing an
        ///      optional callback after completion.
        ///
        ///      Only the opacity is adjusted for this animation, meaning that
        ///      all of the matched elements should already have some form of height
        ///      and width associated with them.
        ///    </summary>
        [PreserveCase]
        public JQuery fadeIn(String speed, BasicCallback callback) { return null; }

        ///<summary>
        ///      Fade in all matched elements by adjusting their opacity and firing an
        ///      optional callback after completion.
        ///
        ///      Only the opacity is adjusted for this animation, meaning that
        ///      all of the matched elements should already have some form of height
        ///      and width associated with them.
        ///    </summary>
        [PreserveCase]
        public JQuery fadeIn(int speed, BasicCallback callback) { return null; }

        ///<summary>
        ///      Fade out all matched elements by adjusting their opacity and firing an
        ///      optional callback after completion.
        ///
        ///      Only the opacity is adjusted for this animation, meaning that
        ///      all of the matched elements should already have some form of height
        ///      and width associated with them.
        ///    </summary>
        [PreserveCase]
        public JQuery fadeOut(String speed, BasicCallback callback) { return null; }

        ///<summary>
        ///      Fade out all matched elements by adjusting their opacity and firing an
        ///      optional callback after completion.
        ///
        ///      Only the opacity is adjusted for this animation, meaning that
        ///      all of the matched elements should already have some form of height
        ///      and width associated with them.
        ///    </summary>
        [PreserveCase]
        public JQuery fadeOut(int speed, BasicCallback callback) { return null; }

        ///<summary>
        ///      Fade the opacity of all matched elements to a specified opacity and firing an
        ///      optional callback after completion.
        ///
        ///      Only the opacity is adjusted for this animation, meaning that
        ///      all of the matched elements should already have some form of height
        ///      and width associated with them.
        ///    </summary>
        [PreserveCase]
        public JQuery fadeTo(String speed, int opacity, BasicCallback callback) { return null; }

        ///<summary>
        ///      Fade the opacity of all matched elements to a specified opacity and firing an
        ///      optional callback after completion.
        ///
        ///      Only the opacity is adjusted for this animation, meaning that
        ///      all of the matched elements should already have some form of height
        ///      and width associated with them.
        ///    </summary>
        [PreserveCase]
        public JQuery fadeTo(int speed, int opacity, BasicCallback callback) { return null; }

        ///<summary>
        ///      A function for making your own, custom animations. The key aspect of
        ///      this function is the object of style properties that will be animated,
        ///      and to what end. Each key within the object represents a style property
        ///      that will also be animated (for example: "height", "top", or "opacity").
        ///
        ///      Note that properties should be specified using camel case
        ///      eg. marginLeft instead of margin-left.
        ///
        ///      The value associated with the key represents to what end the property
        ///      will be animated. If a number is provided as the value, then the style
        ///      property will be transitioned from its current state to that new number.
        ///      Otherwise if the string "hide", "show", or "toggle" is provided, a default
        ///      animation will be constructed for that property.
        ///    </summary>
        [PreserveCase]
        public JQuery animate(Object parameters, String speed, String easing, BasicCallback callback) { return null; }

        ///<summary>
        ///      A function for making your own, custom animations. The key aspect of
        ///      this function is the object of style properties that will be animated,
        ///      and to what end. Each key within the object represents a style property
        ///      that will also be animated (for example: "height", "top", or "opacity").
        ///
        ///      Note that properties should be specified using camel case
        ///      eg. marginLeft instead of margin-left.
        ///
        ///      The value associated with the key represents to what end the property
        ///      will be animated. If a number is provided as the value, then the style
        ///      property will be transitioned from its current state to that new number.
        ///      Otherwise if the string "hide", "show", or "toggle" is provided, a default
        ///      animation will be constructed for that property.
        ///    </summary>
        [PreserveCase]
        public JQuery animate(Object parameters, int speed, String easing, BasicCallback callback) { return null; }


    }
}

