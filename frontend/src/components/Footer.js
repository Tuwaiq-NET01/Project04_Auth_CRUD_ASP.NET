import React from 'react'
import Typography from '@material-ui/core/Typography'
import { makeStyles } from '@material-ui/core/styles'
import Grid from '@material-ui/core/Grid'
import ButtonBase from '@material-ui/core/ButtonBase'
import { Link } from 'react-router-dom'

const useStyles = makeStyles((theme) => ({
  root: {
    flexGrow: 1,
    marginBottom: '2rem',
  },
  button: {
    marginTop: '2rem',
  },
}))

export default function Footer() {
  const classes = useStyles()
  return (
    <Grid container align="center" className={classes.root} spacing={2}>
      <Grid item lg={6} md={12} xs={12} className={classes.button}>
        <Typography align="center">
          &copy; {new Date().getFullYear()} Bitchunk
        </Typography>
      </Grid>
      <Grid item lg={4} md={12} xs={12} container justify="center">
        <Grid item lg={5} md={12} xs={12} align="center">
          <ButtonBase className={classes.button} component={Link} to={'/terms'}>
            <Typography align="center">Terms and Conditions</Typography>
          </ButtonBase>
        </Grid>
        <Grid item lg={4} md={12} xs={12} align="center">
          <ButtonBase
            className={classes.button}
            component={Link}
            to={'/privacy'}
          >
            <Typography align="center">Privacy Policy</Typography>
          </ButtonBase>
        </Grid>
        <Grid item lg={3} md={12} xs={12} align="center">
          <ButtonBase
            className={classes.button}
            href="https://bitchunk-api.azurewebsites.net/swagger/index.html"
            target="_blank"
          >
            <Typography align="center">Bitchunk API</Typography>
          </ButtonBase>
        </Grid>
      </Grid>
    </Grid>
  )
}
