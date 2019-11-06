import * as React from 'react';
import { Link } from 'react-router-dom'
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
            <Title>Iniciar Sesión:</Title>
            <Input label='Email' placeholder='Correo'/>
            <Input label='Contraseña' placeholder='Contraseña'/>
            <Button block={true}>Enviar</Button>
            <Center>
              <Link to='/register'>Ir al registro</Link>
            </Center>
          </Card>
        </Container>
    )
  }
}