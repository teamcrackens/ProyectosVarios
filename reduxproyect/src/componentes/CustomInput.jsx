import React, {Component} from 'react'

export default class CustomInput extends Component {
    render() {
        const { input,meta,title,...props } = this.props
        return(
            <div>
                {title && <span>{title}</span>}
                <input  {...input} {...props} />
                {meta.submitFailed && meta.error && <span style={{color: 'red'}}>{meta.error}</span>}
            </div>
        )
    }
}