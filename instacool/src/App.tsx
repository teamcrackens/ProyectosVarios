import * as React from 'react';
import './App.css';
import Button from './componentes/Button'
import Card from './componentes/Card'
import Center from './componentes/Center'
import Container from './componentes/Container'
import Input from './componentes/Input'
import Link from './componentes/Link'
import Title from './componentes/Title'



class App extends React.Component {
  public render() {
    return (
      <Container>
        <Card>
          <Title>Iniciar Sesión:</Title>
          <Input label='Email' placeholder='Correo'/>
          <Input label='Contraseña' placeholder='Contraseña'/>
          <Button block={true}>Enviar</Button>
          <Center>
            <Link>Ir al registro</Link>
          </Center>
        </Card>
      </Container>
    );
  }
}

export default App;
