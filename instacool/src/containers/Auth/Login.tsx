import * as React from 'react';
import {connect} from 'react-redux'
import Card from '../../componentes/Card'
import Container from '../../componentes/Container'
import LoginForm from '../../componentes/LoginForm'

import { ThunkDispatch } from 'redux-thunk';
import { ILogin,login as loginThunks  } from '../../ducks/Users'

interface ILoginProps{
  login: (a: ILogin ) => void
}

class Login extends React.Component<ILoginProps>{
  public render(){
    const { login } = this.props
    return(
      <Container center={true}>
          <Card>
            <LoginForm onSubmit={login}/>
          </Card>
        </Container>
    )
  }
}

const mapStateToProps = (state: any) => state
 
const mapDispatchToProps = (dispatch: ThunkDispatch<any,any,any>) =>({
  login: (payload: ILogin) => dispatch(loginThunks(payload))
})

export default connect(mapStateToProps,mapDispatchToProps)(Login)