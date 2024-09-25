<script setup>
  import { onMounted, getCurrentInstance, ref } from "vue"
  const weather = await fetchData();

  function fetchData() {
    console.log(__BASEURL__)
    const url = __BASEURL__
    
    return fetch(`${__BASEURL__}/weatherforecast`)
    .then(res=>res.json())
    .then(data => data)
    .catch((err) => {
      console.error(err);
    });
  }
  onMounted(() => {
    fetchData()
})
</script>

<template>
  <div class="greetings">
    <h1 class="green">Forecasts from .NET!!!</h1>
    <ul id="weather">
      <li v-for="forecast in weather">
        {{ forecast.summary }}
      </li>
    </ul>
  </div>
</template>

<style scoped>
h1 {
  font-weight: 500;
  font-size: 2.6rem;
  position: relative;
  top: -10px;
}

h3 {
  font-size: 1.2rem;
}

.greetings h1,
.greetings h3 {
  text-align: center;
}

@media (min-width: 1024px) {
  .greetings h1,
  .greetings h3 {
    text-align: left;
  }
}
</style>
