import React, { useState, useEffect } from 'react'
import { makeStyles } from '@material-ui/core/styles'
import Container from '@material-ui/core/Container'
import Paper from '@material-ui/core/Paper'
import Grid from '@material-ui/core/Grid'
import Typography from '@material-ui/core/Typography'
import TextField from '@material-ui/core/TextField'
import Button from '@material-ui/core/Button'
import CircularProgress from '@material-ui/core/CircularProgress'
import ButtonBase from '@material-ui/core/ButtonBase'
import axios from 'axios'
import { toast } from 'react-toastify'
import { useHistory } from 'react-router-dom'
import Grow from '@material-ui/core/Grow'

const useStyles = makeStyles((theme) => ({
  root: {
    flexGrow: 1,
  },
  rootForm: {
    '& > *': {
      margin: theme.spacing(1),
      width: '75%',
    },
  },
  paper: {
    padding: theme.spacing(2),
    marginBottom: theme.spacing(1),
    marginTop: theme.spacing(6),
    textAlign: 'center',
    color: theme.palette.text.secondary,
    borderRadius: theme.spacing(2),
  },
  large: {
    width: theme.spacing(23),
    height: theme.spacing(8),
    padding: theme.spacing(4),
    margin: 'auto',
  },
  divider: {
    borderBottom: 'solid',
    borderWidth: '1px',
    color: '#ff5722',
    padding: '0.5rem',
    margin: 'auto',
    width: '1.5rem',
  },
  space: {
    paddingTop: '1.5rem',
    paddingBottom: '1.5rem',
    fontSize: '0.8rem',
    textAlign: 'center',
  },
  login: {
    padding: 6,
  },
}))

const emptyNewUser = {
  username: 'admin',
  email: 'admin@bitchunk.co',
  password: 'Admin1325!',
  name: 'Younes Alturkey',
  creationDate: `2021-06-15T20:25:55.772Z`,
  accountType: 'Free',
  currentQuota: 0,
  totalQuota: 50,
}

const AlertSuccess = (msg) => {
  toast.success(`🚀 ${msg}`, {
    position: 'top-right',
    autoClose: 2000,
    hideProgressBar: false,
    closeOnClick: true,
    pauseOnHover: true,
    draggable: true,
    progress: undefined,
  })
}

const AlertError = (msg) => {
  toast.error(`💩 ${msg}`, {
    position: 'top-right',
    autoClose: 2000,
    hideProgressBar: false,
    closeOnClick: true,
    pauseOnHover: true,
    draggable: true,
    progress: undefined,
  })
}

const AlertInfo = (msg) => {
  toast.info(`✌ ${msg}`, {
    position: 'top-right',
    autoClose: 1500,
    hideProgressBar: false,
    closeOnClick: true,
    pauseOnHover: true,
    draggable: true,
    progress: undefined,
  })
}

export default function Auth({ setAuth }) {
  document.title = 'Login'
  const history = useHistory()
  const classes = useStyles()
  const [buttonLoading, setButtonLoading] = useState(() => false)
  const [loginForm, setLoginForm] = useState(() => true)
  const [user, setUser] = useState({
    username: '',
    password: '',
  })
  const [newUser, setNewUser] = useState(emptyNewUser)

  const signup = () => {
    setButtonLoading(true)
    axios
      .post('/api/auth/register', newUser)
      .then((res) => {
        if (res.status === 200) {
          axios
            .post('/api/auth/login', {
              username: newUser.username,
              password: newUser.password,
            })
            .then((res) => {
              if (res.status === 200) {
                localStorage.setItem('UserData', JSON.stringify(res.data))
                setTimeout(() => {
                  setAuth(true)
                  AlertSuccess('Your account has been created.')
                  history.push('/')
                }, 1000)
              }
            })
        }
      })
      .catch((error) => {
        setTimeout(() => {
          setButtonLoading(false)
          AlertError(`${error.response.status} error occured.`)
        }, 1000)
      })
  }

  const login = () => {
    setButtonLoading(true)
    axios
      .post('/api/auth/login', user)
      .then((res) => {
        if (res.status === 200) {
          localStorage.setItem('UserData', JSON.stringify(res.data))
          const name = res.data.name
          setTimeout(() => {
            setAuth(true)
            AlertInfo(`Howdy ${name.split(' ')[0]}.`)
            history.push('/')
          }, 1000)
        }
      })
      .catch((error) => {
        setTimeout(() => {
          setButtonLoading(false)
          AlertError(`${error.response.status} error occured.`)
        }, 1000)
      })
  }

  useEffect(() => {
    const listener = (event) => {
      if (event.code === 'Enter' || event.code === 'NumpadEnter') {
        event.preventDefault()
        if (loginForm) login()
        else signup()
      }
    }
    document.addEventListener('keydown', listener)
    return () => {
      document.removeEventListener('keydown', listener)
    }
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [user, newUser])

  return (
    <Grow direction="up" in={true}>
      <Container className={classes.root}>
        <Grid justify="center" container spacing={3}>
          <Grid item xs={12} lg={6} md={6}>
            {loginForm ? (
              <Paper className={classes.paper} elevation={20}>
                <Typography color="secondary" variant="h5" nowrap="true">
                  Login
                </Typography>
                <div className={classes.divider} />
                <form
                  className={classes.rootForm}
                  noValidate
                  autoComplete="off"
                >
                  <TextField
                    required
                    label="Username"
                    value={user.username}
                    onChange={(e) =>
                      setUser({ ...user, username: e.target.value })
                    }
                    variant="filled"
                    color="secondary"
                  />
                  <TextField
                    required
                    label="Password"
                    value={user.password}
                    onChange={(e) =>
                      setUser({ ...user, password: e.target.value })
                    }
                    variant="filled"
                    color="secondary"
                    type="password"
                  />
                  <Button
                    variant="contained"
                    color="secondary"
                    onClick={() => login()}
                  >
                    {buttonLoading ? (
                      <CircularProgress
                        className={classes.login}
                        size={24}
                        color="inherit"
                      />
                    ) : (
                      <Typography className={classes.login}>Login</Typography>
                    )}
                  </Button>
                </form>
                <ButtonBase
                  disableRipple={true}
                  onClick={() => setLoginForm(false)}
                >
                  <Typography
                    className={classes.space}
                    color="secondary"
                    nowrap="true"
                  >
                    Don't have an account?
                  </Typography>
                </ButtonBase>
              </Paper>
            ) : (
              <Paper className={classes.paper} elevation={20}>
                <Typography color="secondary" variant="h5" nowrap="true">
                  Signup
                </Typography>
                <div className={classes.divider} />
                <form
                  className={classes.rootForm}
                  noValidate
                  autoComplete="off"
                >
                  <TextField
                    required
                    label="Full Name"
                    value={newUser.name}
                    onChange={(e) =>
                      setNewUser({ ...newUser, name: e.target.value })
                    }
                    variant="filled"
                    color="secondary"
                  />
                  <TextField
                    required
                    label="Username"
                    value={newUser.username}
                    onChange={(e) =>
                      setNewUser({ ...newUser, username: e.target.value })
                    }
                    variant="filled"
                    color="secondary"
                  />
                  <TextField
                    required
                    label="Email"
                    value={newUser.email}
                    onChange={(e) =>
                      setNewUser({ ...newUser, email: e.target.value })
                    }
                    variant="filled"
                    color="secondary"
                  />
                  <TextField
                    required
                    label="Password"
                    helperText="Ex: Pass1325!"
                    value={newUser.password}
                    onChange={(e) =>
                      setNewUser({ ...newUser, password: e.target.value })
                    }
                    variant="filled"
                    color="secondary"
                    type="password"
                  />
                  <Button
                    onClick={() => signup()}
                    variant="contained"
                    color="secondary"
                  >
                    {buttonLoading ? (
                      <CircularProgress
                        className={classes.login}
                        size={24}
                        color="inherit"
                      />
                    ) : (
                      <Typography className={classes.login}>Signup</Typography>
                    )}
                  </Button>
                </form>
                <ButtonBase
                  disableRipple={true}
                  onClick={() => setLoginForm(true)}
                >
                  <Typography
                    className={classes.space}
                    color="secondary"
                    nowrap="true"
                  >
                    Have an account?
                  </Typography>
                </ButtonBase>
              </Paper>
            )}
          </Grid>
        </Grid>
      </Container>
    </Grow>
  )
}
