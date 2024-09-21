<template>
	<navigation-bar></navigation-bar>
	<div class="app">
		<router-view></router-view>
	</div>
</template>

<script>
import NavigationBar from "@/components/UI/NavigationBar.vue";

export default {
	components: {NavigationBar}
}
</script>

<style>
@import url('https://fonts.googleapis.com/css2?family=Roboto:wght@400;700&display=swap');

* {
  margin: 0;
  padding: 0;
  box-sizing: border-box;
  font-family: 'Roboto', sans-serif;
  user-select: none;
}

body {
  background-color: #f5f5f5;
  color: #333;
}

.app {
  max-width: 1024px;
  margin: 20px auto;
  padding: 20px;
  border-radius: 10px;
  background-color: #fff;
  box-shadow: 0 2px 4px rgba(0,0,0,0.1);
}
</style>