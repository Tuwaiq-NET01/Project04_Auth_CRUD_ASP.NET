import React, { useEffect, useState } from 'react'
import { makeStyles, withStyles } from '@material-ui/core/styles'
import { useHistory } from 'react-router-dom'
import { toast } from 'react-toastify'
import Container from '@material-ui/core/Container'
import Paper from '@material-ui/core/Paper'
import Grid from '@material-ui/core/Grid'
import CircularProgress from '@material-ui/core/CircularProgress'
import ViewComfyIcon from '@material-ui/icons/ViewComfy'
import BlurOnIcon from '@material-ui/icons/BlurOn'
import DescriptionIcon from '@material-ui/icons/Description'
import ButtonBase from '@material-ui/core/ButtonBase'
import HScrollGrid from 'react-horizontal-scroll-grid'
import ScatterPlotIcon from '@material-ui/icons/ScatterPlot'
import GetAppIcon from '@material-ui/icons/GetApp'
import CloseIcon from '@material-ui/icons/Close'
import Button from '@material-ui/core/Button'
import Badge from '@material-ui/core/Badge'
import Avatar from '@material-ui/core/Avatar'
import TextField from '@material-ui/core/TextField'
import Typography from '@material-ui/core/Typography'
import Grow from '@material-ui/core/Grow'
import axios from 'axios'
import CNKImg from '../assets/img/cnk-icon.png'

const StyledBadge = withStyles((theme) => ({
  badge: {
    backgroundColor: '#44b700',
    color: '#44b700',
    boxShadow: `0 0 0 2px ${theme.palette.background.paper}`,
    '&::after': {
      position: 'absolute',
      top: 0,
      left: 0,
      width: '100%',
      height: '100%',
      borderRadius: '50%',
      animation: '$ripple 1.2s infinite ease-in-out',
      border: '1px solid currentColor',
      content: '""',
    },
  },
  '@keyframes ripple': {
    '0%': {
      transform: 'scale(.8)',
      opacity: 1,
    },
    '100%': {
      transform: 'scale(2.4)',
      opacity: 0,
    },
  },
}))(Badge)

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
  infoBlock: {
    display: 'flex',
    flexDirection: 'column',
    justifyContent: 'center',
    alignItems: 'center',
  },
  infoText: {
    marginTop: theme.spacing(2),
    color: '#32CD32',
    fontSize: '1.5rem',
  },
  cnkChild: {
    width: 50,
    height: 50,
    paddingRight: 200,
  },
  cnkParent: {
    width: '95%',
    height: 100,
    textAlign: 'center',
    display: 'block',
  },
  cnkText: {
    marginTop: theme.spacing(2),
    color: '#32CD32',
    fontSize: '0.9rem',
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

export default function Shredder() {
  document.title = 'Shredder'
  const user = JSON.parse(localStorage.getItem('UserData'))
  const config = {
    headers: {
      Authorization: `Bearer ${user && user.token}`,
      'Content-Type': 'application/json',
    },
  }
  const history = useHistory()
  const fileName = JSON.parse(localStorage.getItem('FileName'))
  const classes = useStyles()
  const [shredded, setShredded] = useState(() => false)
  const [buttonLoading, setButtonLoading] = useState(() => false)
  const [chunksPassword, setChunksPassword] = useState({
    password: '',
    repeat: '',
  })
  const [metaData, setMetaData] = useState({})

  const shred = () => {
    setButtonLoading(true)
    if (
      chunksPassword.password.length <= 1 ||
      chunksPassword.password !== chunksPassword.repeat
    ) {
      setButtonLoading(false)
      AlertError(`Check your AES-256 Keys.`)
      return
    }
    axios
      .post(
        `/api/chunk/${fileName}`,
        { chunksPassword: chunksPassword.password, userId: user && user.id },
        config
      )
      .then((res) => {
        if (res.status === 200) {
          setMetaData(res.data)
          AlertSuccess('Shredding complete.')
          setShredded(true)
          setButtonLoading(false)
        }
      })
      .catch((error) => {
        setButtonLoading(false)
        AlertError(`${error.response.status} error occured.`)
      })
  }

  const downloadRef = () => {
    setButtonLoading(true)
    axios(`/api/chunk/${metaData.referenceFile}`, {
      ...config,
      responseType: 'blob',
    })
      .then((res) => {
        const url = window.URL.createObjectURL(
          new File([res.data], metaData.referenceFile)
        )
        const link = document.createElement('a')
        link.href = url
        link.setAttribute('download', `${metaData.referenceFile}`)
        document.body.appendChild(link)
        link.click()
        link.parentNode.removeChild(link)
        setButtonLoading(false)
        AlertInfo(`Don't lose ${metaData.referenceFile}.`)
        history.push('/')
      })
      .catch((error) => {
        setButtonLoading(false)
        AlertError(`${error.response.status} error occured.`)
      })
  }

  useEffect(() => {
    if (!user) history.push('/login')
    else if (!fileName) {
      history.push('/')
      AlertInfo('Upload a file to shred.')
    }

    return () => {
      if (fileName) {
        localStorage.setItem('FileName', null)
        axios
          .delete(`/api/upload/${fileName}`, config)
          .catch((error) =>
            AlertError(`${error.response.status} error occured.`)
          )
      }
    }
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [])
  return (
    <Grow direction="up" in={true}>
      <Container className={classes.root}>
        <Grid justify="center" container spacing={2}>
          <Grid item xs={12} lg={10} md={8}>
            {shredded ? (
              <Paper className={classes.paper} elevation={20}>
                <Typography color="secondary" variant="h5" nowrap="true">
                  {metaData.fileName + ': '}
                  <span style={{ color: '#32CD32' }}>
                    Gone reduced to chunks
                  </span>
                </Typography>
                <div className={classes.divider} />
                <Grid container spacing={2}>
                  <Grid item lg={3} md={3} xs={12}>
                    <ButtonBase
                      centerRipple={true}
                      onClick={() => downloadRef()}
                    >
                      <div className={classes.infoBlock}>
                        <DescriptionIcon fontSize="large" color="primary" />
                        <Typography
                          color="secondary"
                          variant="h6"
                          nowrap="true"
                          className={classes.infoText}
                        >
                          {metaData.referenceFile}
                        </Typography>
                      </div>
                    </ButtonBase>
                  </Grid>
                  <Grid item lg={3} md={3} xs={12}>
                    <ButtonBase centerRipple={true}>
                      <div className={classes.infoBlock}>
                        <ViewComfyIcon fontSize="large" color="primary" />
                        <Typography
                          color="secondary"
                          variant="h6"
                          nowrap="true"
                          className={classes.infoText}
                        >
                          {parseInt(metaData.fileSize) / 1000} KB
                        </Typography>
                      </div>
                    </ButtonBase>
                  </Grid>
                  <Grid item lg={3} md={3} xs={12}>
                    <ButtonBase centerRipple={true}>
                      <div className={classes.infoBlock}>
                        <ScatterPlotIcon fontSize="large" color="primary" />
                        <Typography
                          color="secondary"
                          variant="h6"
                          nowrap="true"
                          className={classes.infoText}
                        >
                          {metaData.chunksCount + ' chunks'}
                        </Typography>
                      </div>
                    </ButtonBase>
                  </Grid>
                  <Grid item lg={3} md={3} xs={12}>
                    <ButtonBase centerRipple={true}>
                      <div className={classes.infoBlock}>
                        <BlurOnIcon fontSize="large" color="primary" />
                        <Typography
                          color="secondary"
                          variant="h6"
                          nowrap="true"
                          className={classes.infoText}
                        >
                          {parseInt(metaData.chunkSize) / 1000} KB
                        </Typography>
                      </div>
                    </ButtonBase>
                  </Grid>
                  <Grid item xs={12}>
                    <HScrollGrid
                      gridWidth={'90%'}
                      gridHeight={100}
                      cardWidth={200}
                      backgroundColor="white"
                      style={{ cursor: 'pointer' }}
                    >
                      {metaData.chunksMetaData.map((chunk, index) => {
                        return (
                          <div key={index}>
                            <StyledBadge
                              overlap="circle"
                              anchorOrigin={{
                                vertical: 'bottom',
                                horizontal: 'right',
                              }}
                              variant="dot"
                            >
                              <Avatar alt=".CNK Logo" src={CNKImg} />
                            </StyledBadge>
                            <Typography
                              color="secondary"
                              nowrap="true"
                              className={classes.cnkText}
                            >
                              {chunk.substring(0, 9) + '.cnk'}
                            </Typography>
                          </div>
                        )
                      })}
                    </HScrollGrid>
                  </Grid>
                  <Grid item xs={6}>
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
                  <Grid item xs={6}>
                    <Button
                      fullWidth
                      variant="contained"
                      style={{
                        backgroundColor: '#32CD32',
                      }}
                      className={classes.btn}
                      onClick={() => downloadRef()}
                    >
                      {buttonLoading ? (
                        <CircularProgress
                          className={classes.icon}
                          size={24}
                          color="inherit"
                        />
                      ) : (
                        <GetAppIcon className={classes.icon} />
                      )}
                    </Button>
                  </Grid>
                </Grid>
              </Paper>
            ) : (
              <Paper className={classes.paper} elevation={20}>
                <Typography color="secondary" variant="h5" nowrap="true">
                  {'Shred: '}
                  <span style={{ color: '#000' }}>{fileName}</span>
                </Typography>
                <div className={classes.divider} />
                <Grid container spacing={2}>
                  <Grid item xs={12}>
                    <TextField
                      fullWidth
                      label="AES-256 Key"
                      type="password"
                      variant="filled"
                      color="secondary"
                      helperText="Only god can assemble your file if you forget this."
                      defaultValue={chunksPassword.password}
                      onChange={(e) =>
                        setChunksPassword({
                          ...chunksPassword,
                          password: e.target.value,
                        })
                      }
                    />
                  </Grid>
                  <Grid item xs={12}>
                    <TextField
                      fullWidth
                      label="Repeat AES-256 Key"
                      type="password"
                      variant="filled"
                      color="secondary"
                      defaultValue={chunksPassword.repeat}
                      onChange={(e) =>
                        setChunksPassword({
                          ...chunksPassword,
                          repeat: e.target.value,
                        })
                      }
                    />
                  </Grid>
                  <Grid item xs={6}>
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
                  <Grid item xs={6}>
                    <Button
                      fullWidth
                      variant="contained"
                      color="secondary"
                      className={classes.btn}
                      onClick={() => shred()}
                    >
                      {buttonLoading ? (
                        <CircularProgress
                          className={classes.icon}
                          size={24}
                          color="inherit"
                        />
                      ) : (
                        <ScatterPlotIcon className={classes.icon} />
                      )}
                    </Button>
                  </Grid>
                </Grid>
              </Paper>
            )}
          </Grid>
        </Grid>
      </Container>
    </Grow>
  )
}
