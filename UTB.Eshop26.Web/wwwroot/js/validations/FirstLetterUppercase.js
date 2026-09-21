$.validator.addMethod('firstletteruppercase',
function (value, element, params)
{
    if (!value || value == '')
        return true;

    const firstChar = value[0];
    if (firstChar.toUpperCase() === firstChar && firstChar.toLowerCase() !== firstChar)
    {
        return true;
    }

    return false;
});


$.validator.unobtrusive.adapters.add('firstletteruppercase', [],
function (options)
{
    options.rules['firstletteruppercase'] = [options.element];
    options.messages['firstletteruppercase'] = options.message;
});
