import React, { useEffect, useState } from 'react'
import { makeStyles } from '@material-ui/core/styles'
import { useHistory } from 'react-router-dom'
import { toast } from 'react-toastify'
import Container from '@material-ui/core/Container'
import Paper from '@material-ui/core/Paper'
import Grid from '@material-ui/core/Grid'
import CircularProgress from '@material-ui/core/CircularProgress'
import CloseIcon from '@material-ui/icons/Close'
import EditIcon from '@material-ui/icons/Edit'
import Button from '@material-ui/core/Button'
import TextField from '@material-ui/core/TextField'
import Typography from '@material-ui/core/Typography'
import Grow from '@material-ui/core/Grow'
import axios from 'axios'

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
    marginBottom: '2rem',
    margin: 'auto',
    width: '1.5rem',
  },
  space: {
    paddingTop: '1.5rem',
    paddingBottom: '1.5rem',
    fontSize: '0.8rem',
    textAlign: 'center',
  },
  icon: {
    padding: 3,
  },
  btn: {
    marginTop: theme.spacing(1),
  },
}))

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

export default function Profile() {
  const history = useHistory()
  const [grow, setGrow] = useState(() => false)
  const [buttonLoading, setButtonLoading] = useState(() => false)
  const classes = useStyles()
  const [user, setUser] = useState(JSON.parse(localStorage.getItem('UserData')))
  const [password, setPassword] = useState(() => '')
  const [newPassword, setNewPassword] = useState(() => '')

  const updateUser = () => {
    setButtonLoading(true)
    if (
      user.email.length <= 1 ||
      user.name.length <= 1 ||
      password !== newPassword
    ) {
      setTimeout(() => {
        setButtonLoading(false)
        AlertError(`Updated info is required.`)
      }, 1000)
      return
    }
    axios
      .put(`/api/User/${user.id}`, {
        id: user.id,
        email: user.email,
        name: user.name,
        currentPassword: password,
        newPassword: newPassword,
      })
      .then((res) => {
        if (res.status === 200) {
          localStorage.setItem('UserData', JSON.stringify(user))
          setTimeout(() => {
            AlertSuccess('Your profile is updated.')
            history.push('/')
            setButtonLoading(false)
          }, 1000)
        } else {
          setTimeout(() => setButtonLoading(false), 1000)
        }
      })
      .catch((error) => {
        setTimeout(() => {
          AlertError(`${error.response.status} error occured.`)
          setButtonLoading(false)
        }, 1000)
      })
  }

  useEffect(() => {
    document.title = 'Profile'
    setGrow(true)
    if (!user) history.push('/icon')
    const listener = (event) => {
      if (event.code === 'Enter' || event.code === 'NumpadEnter') {
        event.preventDefault()
        updateUser()
      }
    }
    document.addEventListener('keydown', listener)
    return () => {
      document.removeEventListener('keydown', listener)
    }
  })
  return (
    <Grow direction="up" in={grow}>
      <Container className={classes.root}>
        <Grid justify="center" container spacing={2}>
          <Grid item xs={12} lg={10} md={8}>
            <Paper className={classes.paper} elevation={20}>
              <Typography color="secondary" variant="h5" nowrap="true">
                Your Bitchunk Profile
              </Typography>
              <div className={classes.divider} />
              <Grid container spacing={2}>
                <Grid item lg={6} md={6} xs={12}>
                  <TextField
                    disabled
                    fullWidth
                    label="Id"
                    defaultValue={user.id}
                    variant="filled"
                  />
                </Grid>
                <Grid item lg={6} md={6} xs={12}>
                  <TextField
                    disabled
                    fullWidth
                    label="Username"
                    variant="filled"
                    defaultValue={user.username}
                  />
                </Grid>
                <Grid item lg={6} md={6} xs={12}>
                  <TextField
                    fullWidth
                    label="Name"
                    defaultValue={user.name}
                    onChange={(e) => setUser({ ...user, name: e.target.value })}
                    variant="filled"
                    autoFocus={true}
                  />
                </Grid>
                <Grid item lg={6} md={6} xs={12}>
                  <TextField
                    fullWidth
                    label="Email"
                    variant="filled"
                    defaultValue={user.email}
                    onChange={(e) =>
                      setUser({ ...user, email: e.target.value })
                    }
                  />
                </Grid>
                <Grid item lg={6} md={6} xs={12}>
                  <TextField
                    fullWidth
                    label="Current Password"
                    variant="filled"
                    type="password"
                    defaultValue={password}
                    onChange={(e) => setPassword(e.target.value)}
                  />
                </Grid>
                <Grid item lg={6} md={6} xs={12}>
                  <TextField
                    fullWidth
                    label="New Password"
                    variant="filled"
                    type="password"
                    defaultValue={newPassword}
                    onChange={(e) => setNewPassword(e.target.value)}
                  />
                </Grid>
                <Grid item xs={12}>
                  <Button
                    fullWidth
                    variant="contained"
                    color="secondary"
                    className={classes.btn}
                    onClick={() => updateUser()}
                  >
                    {buttonLoading ? (
                      <CircularProgress
                        className={classes.icon}
                        size={24}
                        color="inherit"
                      />
                    ) : (
                      <EditIcon className={classes.icon} />
                    )}
                  </Button>
                  <Button
                    fullWidth
                    variant="contained"
                    color="primary"
                    className={classes.btn}
                    onClick={() => {
                      history.push('/')
                    }}
                  >
                    <CloseIcon className={classes.icon} />
                  </Button>
                </Grid>
              </Grid>
            </Paper>
          </Grid>
        </Grid>
      </Container>
    </Grow>
  )
}
