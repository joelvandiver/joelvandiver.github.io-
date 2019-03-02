module App

open Fable.Core.JsInterop // for the !^ operator
open Fable.Import // to access the Browser api

let initCanvas() =
    let canvas = Browser.document.getElementsByTagName_canvas().[0]
    canvas.width <- 1000.
    canvas.height <- 800.
    let ctx = canvas.getContext_2d()
    // The (!^) operator checks and casts a value to an Erased Union type
    // Used for overloading types
    // See http://fable.io/docs/interacting.html#Erase-attribute for more info
    ctx.fillStyle <- !^"rgb(200,0,0)"
    ctx.fillRect (10., 10., 55., 50.)
    ctx.fillStyle <- !^"rgba(0, 0, 200, 0.5)"
    ctx.fillRect (30., 30., 55., 50.)

initCanvas()
