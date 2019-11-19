import * as React from 'react';
import { Link } from 'react-router-dom'
import { Field } from 'redux-form'
import Button from '../../componentes/Button'
import Card from '../../componentes/Card'
import Center from '../../componentes/Center'
import Container from '../../componentes/Container'
import Input from '../../componentes/Input'
import Title from '../../componentes/Title'



export default class Login extends React.Component{
  public render(){
    return(
      <Container center={true}> 
          <Card>
            <Title>Registro</Title>
            <Field label='Correo' placeholder='Correo' name='email' type='email' component={Input}/>
            <Field label='Contraseña' placeholder='Contraseña' name='password' type='password' component={Input}/>
            {/* <Input label='Email' placeholder='Correo'/>
            <Input label='Contraseña' placeholder='Contraseña'/> */}
            <Button block={true}>Enviar</Button>
            <Center>
              <Link to='/'>Iniciar Sesión</Link>
            </Center>
          </Card>
        </Container>
    )
  }
}