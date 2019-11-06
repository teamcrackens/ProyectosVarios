import React, {Component} from 'react'
import { reduxForm, Field } from 'redux-form'
import CustomInput from './CustomInput'

const validate = values => {
    const errors = {}
    if(!values.name){
        errors.name="campo obligatorio."
    }
    if(!values.lastname){
        errors.lastname="campo obligatorio."
    }

    return errors
}
class UserForm extends Component{
    render(){
        const { handleSubmit } = this.props
        return(
            <form onSubmit={handleSubmit}>
                <Field name="name" component={CustomInput} placeholder="Nombre" title="Nombre: "/>
                <Field name="lastname" component={CustomInput} placeholder="Apellido" title="Apellido: "/>
                <input type="submit" value="Enviar"/>
            </form>
        )
    }
}

export default reduxForm({
    form:'user',
    validate,
})(UserForm)