# Pipe Transform

```
export class NameFilterPipe implements PipeTransform{
    transform(value:Any, text:string){
        if(value.length){ 
            return value.filter(item=>item.name.toUpperCase().startsWith(text.upperCase()));
        }
    }
}
```


> The first argument to the transform function is the value that is passed into the pipe, i.e. the thing that goes before the | in the expression.

> The second parameter to the transform function is the first param we pass into our pipe, i.e. the thing that goes after the : in the expression.